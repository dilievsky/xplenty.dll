using Newtonsoft.Json;

namespace XplentyApi.Model
{
    public class XplentyObject
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public long OwnerId { get; set; }

    }
}