using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
using WebApiMango.ApiMango;

namespace WebApiMango
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly ILogger<CallController> _logger;
        public CallController(ILogger<CallController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<Call>> Post([FromBody] Call call)
        {
            if (call.to.number == "89998887766")
            {
                var serCall = JsonConvert.SerializeObject(call);
                using (FileStream file = new FileStream("log.txt", FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes(serCall);
                    file.Write(buffer, 0, buffer.Length);
                    file.Close();
                }
                return CreatedAtAction(nameof(Post), new { call.to.number });
            }
            return CreatedAtAction(nameof(Post), new { call = "Не то" });
        }
    }
}
