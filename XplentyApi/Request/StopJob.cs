using XplentyApi.Model;

namespace XplentyApi.Request
{
    public class StopJob : XplentyRequest<Job>
    {
        private readonly long jobId;

        public StopJob(long jobId)
        {
            this.jobId = jobId;
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }

        public override string Name
        {
            get { return "Stop job"; }
        }

        public override string Endpoint
        {
            get { return string.Format("jobs/{0}", jobId); }
        }

        public override bool HasBody
        {
            get { return false; }
        }
       
    }
}
