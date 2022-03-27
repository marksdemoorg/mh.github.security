using System;
using Newtonsoft.Json;
namespace mh.github.security.api.Entity.GithubCodeScan
{
	public class Payload
	{
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("alert")]
        public Alert Alert { get; set;  }
        [JsonProperty("repository")]
        public Repository Repository { get; set; }
        public string RawPayload { get; set; }
    }
}
    
