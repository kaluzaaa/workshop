using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace net_core_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {

        [HttpPost]
        public string Post([FromBody] string url)
        {
            string responseFromServer;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }
            response.Close();
            return responseFromServer;
        }
    }
}
