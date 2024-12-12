This is Backend api for a job searching site

• Written in Clean Architecture

• Implemented CQRS using MediatR library

• Authentication and Authorization is implemented using [JWT](https://github.com/jwt-dotnet/jwt) token

• Logging is done using [Serilog](https://github.com/serilog/serilog-aspnetcore)

• Used Redis ( I used Docker for setting up Redis. GetAllVacanciesCached is the endpoint that uses Redis. You have to set up Redis ( Use [Docker](https://www.docker.com/) or [WSL2](https://learn.microsoft.com/en-us/windows/wsl/install) . [Redis is not officially supported on Windows](https://redis.io/docs/latest/operate/oss_and_stack/install/install-redis/install-redis-on-windows/) ) if you want to test it. Otherwise you will get Error 500 ) for caching


• You have to use your own database configuration in appsettings.json
