using System.Collections.Generic;
using XplentyApi.Models;

namespace XplentyApi
{
    public interface IXplentyApi
    {
        string AccountName { get; }

        string ApiKey { get; }

        string Host { get; }

        string Protocol { get; }

        IList<Cluster> ListClusters();

        Cluster GetClusterInformation(long clusterId);

        Cluster CreateCluster(int nodes, ClusterType type, string name, string description, bool terminateOnIdle, long timeToIdle);

        Cluster UpdateCluster(long id, int nodes, string name, string description, bool terminateOnIdle, long timeToIdle);

        Cluster TerminateCluster(long clusterId);

        IList<Job> ListJobs();

        Job GetJobInformation(long jobId);

        Job RunJob(long clusterId, long packageId, IDictionary<string, string> variables);

        Job StopJob(long jobId);

    }
}
