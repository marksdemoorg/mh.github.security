using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mh.github.security.api.Controllers
{
    [Route("api/[controller]")]
    public class RepoCreatedController : Controller
    {
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Entity.GithubRepo.Payload payload)
        {
            if(payload.Action == "created")
            {
                //When an action is created we need to store this and queue a call back to the Github API to
                //Enable security alerts
                //
                //https://docs.github.com/en/rest/reference/repos#enable-vulnerability-alerts
                //
                //PUT /repos/{owner}/{repo}/vulnerability-alerts
                //
                //Addtionally, we need to call the create an issue that outlines the protections added.
                //
                //https://docs.github.com/en/rest/reference/issues#create-an-issue
                //
                //PUT /repos/{owner}/{repo}/vulnerability-alerts
                //
                //This would have to be queued to run later as the webhook times out in 10 seconds.
                Console.WriteLine("A new repos was created: " + payload.Repository.Name);
                Console.WriteLine("API Url: " + payload.Repository.Url);
            }

            return Ok();
        }
    }
}

