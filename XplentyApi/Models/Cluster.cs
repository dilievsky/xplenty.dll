using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XplentyApi.Utils;

namespace XplentyApi.Models
{
    public class Cluster : XplentyObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClusterStatus Status { get; set; }

        [JsonProperty(PropertyName = "nodes")]
        public int Nodes { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClusterType Type { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        [JsonProperty(PropertyName = "available_since")]
        public DateTime? AvailableSince { get; set; }
        
        [JsonProperty(PropertyName = "terminated_at")]
        public DateTime? TerminatedAt { get; set; }
        
        [JsonProperty(PropertyName = "running_jobs_count")]
        public long RunningJobsCount { get; set; }
        
        [JsonProperty(PropertyName = "time_to_idle")]
        public long TimeToIdle { get; set; }

        [JsonProperty(PropertyName = "terminated_on_idle")]
        [JsonConverter(typeof(BoolConverter))]
        public bool TerminatedOnIdle { get; set; }

        [JsonProperty(PropertyName = "terminate_on_idle")]
        public string TerminateOnIdle { get; set; }
    }
}