using XplentyApi.Models;

namespace XplentyApi.Requests
{
    public class ClusterInfo : XplentyRequest<Cluster>
    {
        private readonly long clusterId;

        public ClusterInfo(long clusterId)
        {
            this.clusterId = clusterId;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string Name
        {
            get { return "Get cluster information"; }
        }

        public override string Endpoint
        {
            get { return string.Format("clusters/{0}", clusterId); }
        }

        public override bool HasBody
        {
            get { return false; }
        }
    }
}