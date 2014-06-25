using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using XplentyApi.Connectors;
using XplentyApi.Models;
using XplentyApi.Requests;

namespace XplentyApi.Test
{
    public class ApiCallsTests
    {
        private IXplentyApi xplentyApi;


        public void Initiator()
        {
            
        }

        private static Mock<IConnector> CreateMockConnector(string accountName, string apiKey, string protocol="https", string host="david.api.com")
        {
            var mockConnector = new Mock<IConnector>();
            mockConnector.Object.AccountName = accountName;
            mockConnector.Object.ApiKey = apiKey;
            mockConnector.Object.Protocol = protocol;
            mockConnector.Object.Host = host;

            return mockConnector;
        }

        [Test]
        public void TestProperties()
        {
            xplentyApi = new XplentyApi("demoAccount","asdasd");            

            Assert.AreEqual("demoAccount", xplentyApi.AccountName);
            Assert.AreEqual("asdasd", xplentyApi.ApiKey);

            xplentyApi = new XplentyApi("anotherAccount", "asdag34trtgdg", "api.david.com", "http");

            Assert.AreEqual("anotherAccount", xplentyApi.AccountName);
            Assert.AreEqual("asdag34trtgdg", xplentyApi.ApiKey);
            Assert.AreEqual("api.david.com", xplentyApi.Host);
            Assert.AreEqual("http", xplentyApi.Protocol);
        }


        [Test]
        public void TestListClusters()
        {
            xplentyApi = new XplentyApi("demoAccount", "asdasd");

            Assert.Throws<NotImplementedException>(() => xplentyApi.ListClusters());
        }

        [Test]
        public void TestGetClusterInformation()
        {
            var mockConnector = CreateMockConnector("demoAccount","asdasd"); 

            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Cluster>>(req => req.Name=="Get cluster information"))).Returns(new Cluster{Id = 3});            
            
            xplentyApi = new XplentyApi(mockConnector.Object);

            var cluster = xplentyApi.GetClusterInformation(3);

            Assert.IsNotNull(cluster);
            Assert.AreEqual(3,cluster.Id);
        }

        [Test]
        public void TestCreateCluster()
        {
            var testCluster = new Cluster
                {
                    Id = 7,
                    AvailableSince = DateTime.Now,
                    Type = ClusterType.Production,
                    Name = "asd",
                    Nodes = 4,
                    Description = "asfgfdh",
                    TerminateOnIdle = "True",
                    TimeToIdle = 222
                };

            var mockConnector = CreateMockConnector("demoAccount", "asdasd");
            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Cluster>>(req => req.Name == "Create cluster"))).Returns(testCluster);


            xplentyApi = new XplentyApi(mockConnector.Object);

            var cluster = xplentyApi.CreateCluster(testCluster.Nodes,testCluster.Type,testCluster.Name,testCluster.Description,true,testCluster.TimeToIdle);

            Assert.IsNotNull(cluster);
            Assert.AreEqual(7, cluster.Id);
        }

        [Test]
        public void TestUpdateCluster()
        {
            xplentyApi = new XplentyApi("demoAccount", "asdasd");

            Assert.Throws<NotImplementedException>(() => xplentyApi.UpdateCluster(1,1,"a","a",true,222));

        }

        [Test]
        public void TestTerminateCluster()
        {
            var mockConnector = CreateMockConnector("demoAccount", "asdasd");
            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Cluster>>(req => req.Name == "Terminate cluster"))).Returns(new Cluster());

            xplentyApi = new XplentyApi(mockConnector.Object);

            var cluster = xplentyApi.TerminateCluster(7);
            Assert.IsNotNull(cluster);
        }

        [Test]
        public void TestListJobs()
        {
            xplentyApi = new XplentyApi("demoAccount", "asdasd");

            Assert.Throws<NotImplementedException>(() => xplentyApi.ListJobs());
        }

        [Test]
        public void TestGetJobInformation()
        {
            var mockConnector = CreateMockConnector("demoAccount", "asdasd");
            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Job>>(req => req.Name == "Get job info"))).Returns(new Job{Id = 7});

            xplentyApi = new XplentyApi(mockConnector.Object);

            var job = xplentyApi.GetJobInformation(7);
            Assert.IsNotNull(job);
            Assert.AreEqual(7,job.Id);
        }

        [Test]
        public void TestRunJob()
        {
            var mockConnector = CreateMockConnector("demoAccount", "asdasd");
            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Job>>(req => req.Name == "Run Job"))).Returns(new Job { ClusterId = 6, PackageId = 234 });

            xplentyApi = new XplentyApi(mockConnector.Object);

            var job = xplentyApi.RunJob(6,234,new Dictionary<string, string>());
            Assert.IsNotNull(job);
        }

        [Test]
        public void TestStopJob()
        {
            var mockConnector = CreateMockConnector("demoAccount", "asdasd");
            mockConnector.Setup(f => f.SendRequest(It.Is<XplentyRequest<Job>>(req => req.Name == "Stop job"))).Returns(new Job());

            xplentyApi = new XplentyApi(mockConnector.Object);

            var job = xplentyApi.StopJob(7);
            Assert.IsNotNull(job);
        }

    }
}
