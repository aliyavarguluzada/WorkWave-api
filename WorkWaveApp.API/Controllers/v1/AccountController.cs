

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiversion}/account")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ServiceResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
            => await Mediator.Send(new RegisterCommand(request));

        [HttpPost("login")]
        public async Task<ServiceResult<LoginResponse>> Login([FromBody] LoginRequest request)
            => await Mediator.Send(new LoginCommand(request));

        [HttpGet("users")]
        public async Task<List<User>> Users()
        {
            var users = await accountService.GetAllUsers();
            return users;
        }
    }
}
