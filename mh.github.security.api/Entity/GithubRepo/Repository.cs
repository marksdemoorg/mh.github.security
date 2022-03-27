using System;
using Newtonsoft.Json;

namespace mh.github.security.api.Entity.GithubRepo
{
	public class Repository
	{
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

