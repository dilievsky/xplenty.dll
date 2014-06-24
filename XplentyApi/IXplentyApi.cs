using System;
using System.Collections.Generic;
using XplentyApi.Model;

namespace XplentyApi
{
    public interface IXplentyApi
    {

        IList<Cluster> ListClusters();

        Cluster GetClusterInformation(long clusterId);

        Cluster CreateCluster(int nodes, ClusterType type, string name, string description, bool terminateOnIdle,
                              long timeToIdle);

        Cluster UpdateCluster(long id, int nodes, string name, string description, bool terminateOnIdle, long timeToIdle);

        Cluster TerminateCluster(long clusterId);

        IList<Job> ListJobs();

        Job GetJobInformation(long jobId);

        Job RunJob(long clusterId, long packageId, IDictionary<string, string> variables);

        Job StopJob(long jobId);

        //IList<Watcher> listClusterWatchers(long clusterId);



        //IList<Watcher> listJobWatchers(long clusterId);



        //    public ClusterWatchingLogEntry addClusterWatchers(long clusterId) {
        //        return this.execute(new AddClusterWatcher(clusterId)).withParentApiInstance(this);
        //    }
        //
        //    public JobWatchingLogEntry addJobWatchers(long jobId) {
        //        return this.execute(new AddJobWatcher(jobId)).withParentApiInstance(this);
        //    }
        //
        //
        //    public Boolean removeClusterWatchers(long clusterId) {
        //        return this.execute(new WatchingStop(Xplenty.SubjectType.CLUSTER, clusterId));
        //    }
        //
        //    public Boolean removeJobWatchers(long jobId) {
        //        return this.execute(new WatchingStop(Xplenty.SubjectType.JOB, jobId));
        //    }


        string GetAccountName();

        string GetApiKey();

        string GetHost();


        Version GetVersion();

    }
}
