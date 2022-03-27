using System;
using Newtonsoft.Json;

namespace mh.github.security.api.Entity.GithubRepo
{
	public class Payload
	{
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("repository")]
        public Repository Repository { get; set; }
    }
}

