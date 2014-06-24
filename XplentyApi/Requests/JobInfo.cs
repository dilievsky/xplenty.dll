using XplentyApi.Models;

namespace XplentyApi.Requests
{
    public class JobInfo : XplentyRequest<Job>
    {
        private readonly long jobId;

        public JobInfo(long jobId)
        {
            this.jobId = jobId;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string Name
        {
            get { return "Get job info"; }
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