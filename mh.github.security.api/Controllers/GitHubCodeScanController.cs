using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using GithubCodeScan = mh.github.security.api.Entity.GithubCodeScan;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mh.github.security.api.Controllers
{
    [Route("api/[controller]")]
    public class GitHubCodeScanController : Controller
    {
        private readonly IDistributedCache cache;

        public GitHubCodeScanController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        
        [HttpGet]
        public async Task<string> GetAsync(string key)
        {
            //This will return the contents of the webhook playload for the provided
            //Delivery id, will return an empty string if none is found.
            var result = await cache.GetAsync(key);

            if(result != null)
            {
                return Encoding.UTF8.GetString(result);
            }

            return string.Empty;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] GithubCodeScan.Request githubRequest)
        {
            //This will handle webhook POST requests from Github for Code Scan
            //issues.
            Request.Headers.TryGetValue("X-GitHub-Delivery", out StringValues delivery);

            //The Payload object represents a subset of the data provided in the Github request
            //and could be expanded or shrunk depending on the data the service is interested in.
            var payload = JsonConvert.DeserializeObject<GithubCodeScan.Payload>(githubRequest.Payload);
            if(payload != null)
            {
                payload.RawPayload = githubRequest.Payload;
            }
            
            var jsonPayload = JsonConvert.SerializeObject(payload);

            //Saving the data to Redis for simplicity, however this could be SQL NoSQL also.
            await cache.SetAsync(delivery, Encoding.UTF8.GetBytes(jsonPayload));

            return Ok();
        }
    }
}

