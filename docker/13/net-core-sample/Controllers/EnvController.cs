using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace net_core_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EnvController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public string Get()
        {
            return _config.GetValue<string>("TestEnv");
        }
    }
}
