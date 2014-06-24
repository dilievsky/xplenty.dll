using System;
using System.Collections.Generic;
using XplentyApi.Connectors;
using XplentyApi.Models;
using XplentyApi.Requests;

namespace XplentyApi
{
    public class XplentyApi : IXplentyApi
    {
        private readonly IConnector connector;
        
        public string AccountName { get { return connector.AccountName; }}
        public string ApiKey { get { return connector.ApiKey; } }
        public string Host { get { return connector.Host; } }
        public string Protocol { get { return connector.Protocol; } }
        
        public XplentyApi(string accountName, string apiKey)
        {   
            connector = new RestConnector(accountName,apiKey);
        }
        
        public XplentyApi(string accountName, string apiKey, string host, string protocol) : this(accountName, apiKey)
        {
            connector.Host = host;
            connector.Protocol = protocol;
        }

        public XplentyApi(IConnector connector)
        {
            this.connector = connector;
        }
                
        public Cluster GetClusterInformation(long clusterId)
        {
            var request = new ClusterInfo(clusterId);
            
            return connector.SendRequest(request);
        }

        public Cluster CreateCluster(int nodes, ClusterType type, string name, string description, bool terminateOnIdle, long timeToIdle)
        {
            var cluster = new Cluster
                {
                    Nodes = nodes,
                    Type = type,
                    Name = name,
                    Description = description,
                    TerminateOnIdle = terminateOnIdle.ToString(),
                    TimeToIdle = timeToIdle
                };

            var request = new CreateCluster(cluster);

            return connector.SendRequest(request);
        }

        public Cluster TerminateCluster(long clusterId)
        {
            var request = new TerminateCluster(clusterId);

            return connector.SendRequest(request);
        }

        public Job GetJobInformation(long jobId)
        {
            var request = new JobInfo(jobId);

            return connector.SendRequest(request);
        }

        public Job RunJob(long clusterId, long packageId, IDictionary<string, string> variables)
        {
            var job = new Job
                {
                    ClusterId = clusterId,
                    PackageId = packageId,
                    Variables = variables
                };

            var request = new RunJob(job);

            return connector.SendRequest(request);
        }

        public Job StopJob(long jobId)
        {
            var request = new StopJob(jobId);

            return connector.SendRequest(request);
        }

        public Cluster UpdateCluster(long id, int nodes, string name, string description, bool terminateOnIdle, long timeToIdle)
        {
            throw new NotImplementedException();
        }

        public IList<Cluster> ListClusters()
        {
            throw new NotImplementedException();
        }

        public IList<Job> ListJobs()
        {
            throw new NotImplementedException();
        }
    }
}
