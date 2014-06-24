using System;
using Newtonsoft.Json;

namespace XplentyApi.Models
{
    public class XplentyObject
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}