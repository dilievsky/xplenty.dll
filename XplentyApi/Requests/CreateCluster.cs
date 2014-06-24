using Newtonsoft.Json;
using XplentyApi.Models;

namespace XplentyApi.Requests
{
    public class CreateCluster : XplentyRequest<Cluster>
    {
        private readonly Cluster cluster;

        public override string Name
        {
            get { return "Create cluster"; }
        }

        public override string Endpoint
        {
            get { return "clusters"; }
        }

        public override string Body
        {
            get
            {

                return JsonConvert.SerializeObject(new { cluster = cluster }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        public override bool HasBody
        {
            get { return true; }
        }


        public CreateCluster(Cluster cluster)
        {
            this.cluster = cluster;
        }
       
    }
}
