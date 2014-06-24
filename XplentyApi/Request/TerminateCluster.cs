using XplentyApi.Model;

namespace XplentyApi.Request
{
    public class TerminateCluster : XplentyRequest<Cluster>
    {
        private readonly long clusterId;

        public TerminateCluster(long clusterId)
        {
            this.clusterId = clusterId;
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }

        public override string Name
        {
            get { return "Terminate cluster"; }
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
