using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Newtonsoft.Json;
using XplentyApi.Models;

namespace XplentyApi.Test
{
    public class Class1
    {
        [Test]
        public void Sanity()
        {
            var xp = new XplentyApi("walkmeqa", "QuNwxEP5LpXyh1zvwEzq");

            //var cluster = xp.CreateCluster(1, ClusterType.Sandbox, "WalkMe Cluster", "asdasd", false, 200);

            var cluster = xp.GetClusterInformation(6642);
            while (cluster.Status != ClusterStatus.Available && cluster.Status != ClusterStatus.Idle)
            {
                Thread.Sleep(20000);
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
                Thread.Sleep(20000);
                job = xp.GetJobInformation(job.Id);
            }

            xp.TerminateCluster(cluster.Id);
            cluster = xp.GetClusterInformation(6639);
            while (cluster.Status != ClusterStatus.Terminated)
            {
                Thread.Sleep(20000);
                cluster = xp.GetClusterInformation(cluster.Id);
            }
        }

        [Test]
        public void TestClusterResponseCasting()
        {
            var response =
                "{\"id\":6636,\"name\":\"WalkMe Cluster\",\"description\":\"asdasd\",\"status\":\"pending\",\"owner_id\":277,\"plan_id\":null,\"nodes\":1,\"type\":\"sandbox\",\"created_at\":\"2014-06-24T10:16:29Z\",\"updated_at\":\"2014-06-24T10:16:29Z\",\"available_since\":null,\"terminated_at\":null,\"launched_at\":null,\"terminate_on_idle\":false,\"time_to_idle\":200,\"terminated_on_idle\":false,\"running_jobs_count\":0,\"url\":\"https://api.xplenty.com/walkmeqa/api/clusters/6636\"}";

            var cluster = JsonConvert.DeserializeObject<Cluster>(response);

            var resJob =
                "{\"id\":298973,\"status\":\"pending_stoppage\",\"variables\":{},\"owner_id\":277,\"progress\":0.0,\"outputs_count\":0,\"started_at\":\"2014-06-24T12:37:02Z\",\"completed_at\":null,\"failed_at\":null,\"created_at\":\"2014-06-24T12:36:57Z\",\"updated_at\":\"2014-06-24T12:37:22Z\",\"cluster_id\":6642,\"package_id\":3044,\"errors\":null,\"url\":\"https://api.xplenty.com/walkmeqa/api/jobs/298973\",\"outputs\":[],\"runtime_in_seconds\":20}";
            var job = JsonConvert.DeserializeObject<Job>(resJob);

            var r =
                "{\"id\":6642,\"name\":\"WalkMe Cluster\",\"description\":\"asdasd\",\"status\":\"pending_terminate\",\"owner_id\":277,\"plan_id\":null,\"nodes\":1,\"type\":\"sandbox\",\"created_at\":\"2014-06-24T12:23:32Z\",\"updated_at\":\"2014-06-24T12:51:15Z\",\"available_since\":\"2014-06-24T12:50:10Z\",\"terminated_at\":null,\"launched_at\":\"2014-06-24T12:35:45Z\",\"terminate_on_idle\":false,\"time_to_idle\":200,\"terminated_on_idle\":false,\"running_jobs_count\":0,\"url\":\"https://api.xplenty.com/walkmeqa/api/clusters/6642\"}";
            cluster = JsonConvert.DeserializeObject<Cluster>(r);
        }
    }
}
