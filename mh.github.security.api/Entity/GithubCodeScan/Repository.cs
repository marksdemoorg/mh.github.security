using System;
using Newtonsoft.Json;

namespace mh.github.security.api.Entity.GithubCodeScan
{
	public class Repository
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }
}

