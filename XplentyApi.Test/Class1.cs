using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using XplentyApi.Model;

namespace XplentyApi.Test
{
    public class Class1
    {
        [Test]
        public void Sanity()
        {
            var xp = new XplentyApi("walkmeqa", "QuNwxEP5LpXyh1zvwEzq");

            var cluster = xp.CreateCluster(1, ClusterType.Sandbox, "WalkMe Cluster", "asdasd", false, 200);

            cluster = xp.GetClusterInformation(cluster.Id);
            while (cluster.Status != ClusterStatus.Available)
            {
                cluster = xp.GetClusterInformation(cluster.Id);
            }

            var job = xp.RunJob(cluster.Id, 3044, new Dictionary<string, string>());

            job = xp.GetJobInformation(job.Id);
            while (job.Status != JobStatus.Running)
            {
                job = xp.GetJobInformation(job.Id);
            }

            xp.StopJob(job.Id);
            while (job.Status != JobStatus.Stopped)
            {
                job = xp.GetJobInformation(job.Id);
            }

            xp.TerminateCluster(cluster.Id);
        }

        [Test]
        public void TestClusterResponseCasting()
        {
            var response =
                "{\"id\":6636,\"name\":\"WalkMe Cluster\",\"description\":\"asdasd\",\"status\":\"pending\",\"owner_id\":277,\"plan_id\":null,\"nodes\":1,\"type\":\"sandbox\",\"created_at\":\"2014-06-24T10:16:29Z\",\"updated_at\":\"2014-06-24T10:16:29Z\",\"available_since\":null,\"terminated_at\":null,\"launched_at\":null,\"terminate_on_idle\":false,\"time_to_idle\":200,\"terminated_on_idle\":false,\"running_jobs_count\":0,\"url\":\"https://api.xplenty.com/walkmeqa/api/clusters/6636\"}";

            var cluster = JsonConvert.DeserializeObject<Cluster>(response);
        }
    }
}
