using System;
using System.Collections.Generic;
using XplentyApi.Model;
using XplentyApi.Request;

namespace XplentyApi
{
    public class XplentyApi : WebConnectivity, IXplentyApi
    {
        public XplentyApi(string accountName, string apiKey) : base(accountName, apiKey){}
        
        public XplentyApi(string accountName, string apiKey, string host, string protocol) : base(accountName, apiKey, host, protocol){}
        
        public IList<Cluster> ListClusters()
        {
            throw new NotImplementedException();
        }

        public Cluster GetClusterInformation(long clusterId)
        {
            var request = new ClusterInfo(clusterId);
            
            return SendRequest(request);
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

            return SendRequest(request);
        }

        public Cluster UpdateCluster(long id, int nodes, string name, string description, bool terminateOnIdle, long timeToIdle)
        {
            throw new NotImplementedException();
        }

        public Cluster TerminateCluster(long clusterId)
        {
            var request = new TerminateCluster(clusterId);

            return SendRequest(request);
        }

        public IList<Job> ListJobs()
        {
            throw new NotImplementedException();
        }

        public Job GetJobInformation(long jobId)
        {
            var request = new JobInfo(jobId);

            return SendRequest(request);
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

            return SendRequest(request);
        }

        public Job StopJob(long jobId)
        {
            var request = new StopJob(jobId);

            return SendRequest(request);
        }

        public string GetAccountName()
        {
            return AccountName;
        }

        public string GetApiKey()
        {
            return ApiKey;
        }

        public string GetHost()
        {
            return Host;
        }

        public Version GetVersion()
        {
            throw new NotImplementedException();
        }
    }
}
