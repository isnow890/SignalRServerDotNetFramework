using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SignalRServerDotNetFramework.Hub;

namespace SignalRServerDotNetFramework.Controllers
{
    [RoutePrefix("hub")]
    public class HubController : ApiController
    {
        [Route("send-message")]
        [HttpPost]
        public async Task<IHttpActionResult> SendHubMessage([FromBody] IList<HubProperty> model)
        {
            try
            {
                var tasks = model.Select(async g => await NotificationHub.SendAsync(g.hspTpCd, g.stfNo, g.message));
                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }

            return Ok(new Dictionary<string, dynamic>
            {
                { "reqCount", model.Count }, { "sentDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "reqData", model }
            });
        }

        public class HubProperty
        {
            public string hspTpCd { get; set; }
            public string stfNo { get; set; }
            public string message { get; set; }
        }
    }
}