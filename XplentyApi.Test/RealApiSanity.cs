using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace XplentyApi.Test
{
    public class RealApiSanity
    {
        [Test]
        public void Sanity()
        {
            var xp = new XplentyApi("", "");
        
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
    }
}
