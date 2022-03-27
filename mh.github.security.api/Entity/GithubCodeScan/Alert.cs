using System;
using Newtonsoft.Json;

namespace mh.github.security.api.Entity.GithubCodeScan
{
	public class Alert
	{
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}

