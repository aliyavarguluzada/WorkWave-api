using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Models.v1.Account.Register;

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/home")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        }


    }
}
