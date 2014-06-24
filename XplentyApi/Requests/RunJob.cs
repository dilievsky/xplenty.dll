using Newtonsoft.Json;
using XplentyApi.Models;

namespace XplentyApi.Requests
{
    public class RunJob : XplentyRequest<Job>
    {
        private readonly Job job;

        public override string Name
        {
            get { return "Run Job"; }
        }

        public override string Endpoint
        {
            get { return "jobs"; }
        }

        public override string Body
        {
            get
            {
                return JsonConvert.SerializeObject(new { job = job }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        public override bool HasBody
        {
            get { return true; }
        }


        public RunJob(Job job)
        {
            this.job = job;
        }
       
    }
}
