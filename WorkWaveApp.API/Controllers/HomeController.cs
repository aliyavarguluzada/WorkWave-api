using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkWaveApp.API.Controllers
{
    [Route("api/v{version:apiVersion}/account")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HomeController : BaseController
    {

    }
}
