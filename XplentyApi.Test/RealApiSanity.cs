using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace XplentyApi.Test
{
    public class RealApiSanity
    {
        private const string AccountId = "";
        private const string ApiKey = "";
        private const int PackageId = 3044;

        [Test]
        public void Sanity()
        {
            var xp = new XplentyApi(AccountId, ApiKey);
        
            var cluster = xp.CreateCluster(1, ClusterType.Sandbox, "Test Cluster", "asdasd", false, 200);
        
            Assert.NotNull(cluster);
            Assert.AreEqual(1,cluster.Nodes);
            Assert.AreEqual(ClusterType.Sandbox, cluster.Type);
            Assert.AreEqual("Test Cluster", cluster.Name);
            Assert.AreEqual("asdasd", cluster.Description);
            Assert.AreEqual("False", cluster.TerminateOnIdle);
            Assert.AreEqual(200,cluster.TimeToIdle);
            
            while (cluster.Status != ClusterStatus.Available && cluster.Status != ClusterStatus.Idle)
            {
                Thread.Sleep(20000);
                cluster = xp.GetClusterInformation(cluster.Id);
            }

            var job = xp.RunJob(cluster.Id, PackageId, new Dictionary<string, string>());
            Assert.NotNull(job);
            Assert.AreEqual(PackageId, job.PackageId);
            Assert.AreEqual(cluster.Id, job.ClusterId);

            while (job.Status != JobStatus.Running)
            {
                Thread.Sleep(3000);
                job = xp.GetJobInformation(job.Id);
            }
        
            xp.StopJob(job.Id);
            while (job.Status != JobStatus.Stopped)
            {
                Thread.Sleep(10000);
                job = xp.GetJobInformation(job.Id);
            }
        
            xp.TerminateCluster(cluster.Id);
            cluster = xp.GetClusterInformation(cluster.Id);
            while (cluster.Status != ClusterStatus.Terminated)
            {
                Thread.Sleep(20000);
                cluster = xp.GetClusterInformation(cluster.Id);
            }

            Assert.AreEqual(ClusterStatus.Terminated,cluster.Status);
        }
    }
}
