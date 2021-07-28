using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;

namespace net_core_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {

        private readonly IConfiguration _config;

        public RedisController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {

            var manager = new RedisManagerPool(_config.GetValue<string>("RedisConnectionString"));
            using (var client = manager.GetClient())
            {
                return client.Get<string>(key);
            }
        }

        [HttpPost]
        public void Post([FromBody] Item request)
        {
            var manager = new RedisManagerPool(_config.GetValue<string>("RedisConnectionString"));
            using (var client = manager.GetClient())
            {
                client.Set(request.Key, request.Value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string key)
        {
            var manager = new RedisManagerPool(_config.GetValue<string>("RedisConnectionString"));
            using (var client = manager.GetClient())
            {
                client.Delete<string>(key);
            }
        }
    }

    public class Item
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
