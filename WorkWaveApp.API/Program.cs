

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks();

builder.Services.ConfigureHealthChecks(builder.Configuration);

builder.WebHost.UseKestrel(option => option.AddServerHeader = false);





builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});


//builder.Services.AddOutputCache(options =>
//{
//    options.AddBasePolicy(builder =>
//        builder.Expire(TimeSpan.FromMinutes(15)));

//});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Default", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());

    options.AddPolicy("company", new AuthorizationPolicyBuilder()
        .RequireRole("company")
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
    options.AddPolicy("admin", new AuthorizationPolicyBuilder()
        .RequireRole("admin")
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
});

// code is for ignoring cycles otherwise an exception occurs
builder.Services.AddControllers().AddJsonOptions(options =>
{

    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 128;

});


builder.Services.AddCors();


var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
       .Build();


try
{
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)

        .CreateLogger();

    builder.Logging.ClearProviders();

    builder.Logging.AddSerilog(logger);

    Log.Information("Starting Web Application");

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services).WriteTo.File("Logs/log-.json", Serilog.Events.LogEventLevel.Verbose, rollingInterval: RollingInterval.Day));// does not work when added from configuration not sure why

    var app = builder.Build();



    app.UseSerilogRequestLogging();

    app.UseRouting();

    //app.UseEndpoints(routes =>
    //{
    //    routes.MapHub<ChatHub>("/chatHub");
    //});


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "1");
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.MapHealthChecks("/api/v{api:apiVersion}/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.UseHealthChecksUI(delegate (HealthChecks.UI.Configuration.Options options)
    {
        options.UIPath = $"/api/v{1}/healthcheck-ui";
        options.ApiPath = $"/api/v{1}/healthcheck-api";

    });

    //app.UseOutputCache();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlushAsync();
}
