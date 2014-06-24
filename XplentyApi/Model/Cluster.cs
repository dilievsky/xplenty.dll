using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XplentyApi.Utils;

namespace XplentyApi.Model
{
    public class Cluster : XplentyObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ClusterStatus Status { get; set; }

        [JsonProperty(PropertyName = "nodes")]
        public int Nodes { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClusterType Type { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        [JsonProperty(PropertyName = "available_since")]
        public DateTime? AvailableSince { get; set; }
        
        [JsonProperty(PropertyName = "terminated_at")]
        public DateTime? TerminatedAt { get; set; }
        
        [JsonProperty(PropertyName = "running_jobs_count")]
        public long RunningJobsCount { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        
        [JsonProperty(PropertyName = "time_to_idle")]
        public long TimeToIdle { get; set; }

        [JsonProperty(PropertyName = "terminated_on_idle")]
        [JsonConverter(typeof(BoolConverter))]
        public bool TerminatedOnIdle { get; set; }

        [JsonProperty(PropertyName = "terminate_on_idle")]
        public string TerminateOnIdle { get; set; }


        //	public Cluster withTerminateOnIdle(Boolean terminateOnIdle) {
        //		this.terminateOnIdle = terminateOnIdle;
        //		return this;
        //	}

        //	public Cluster withTimeToIdle(Long timeToIdle) {
        //		this.timeToIdle = timeToIdle;
        //		return this;
        //	}

        /**
         * Shorthand method for {@code waitForStatus(null, ClusterStatus...)} Will wait forever until the required status is received.
         * @param statuses see {@link #waitForStatus(Long, ClusterStatus...)}
         */
        //	public void waitForStatus(ClusterStatus... statuses) {
        //		waitForStatus(null, statuses);
        //	}

        /**
         * Blocks execution until required status is received from the Xplenty server, or until timeout occurs.
         * @param timeout time in seconds before terminating the wait, {@code null} to wait forever
         * @param statuses list of statuses to wait for, see {@link ClusterStatus} for the list of supported statuses
         */
        //	public void waitForStatus(Long timeout, ClusterStatus... statuses) {
        //		if (getParentApiInstance() == null)
        //			throw new XplentyAPIException("The parent API instance is not set");
        //		long start = System.currentTimeMillis();
        //		statusWait:
        //		while (true) {
        //			try {
        //				Thread.sleep(XplentyObject.StatusRefreshInterval);
        //			} catch (InterruptedException e) {
        //				throw new XplentyAPIException("Error sleeping", e);
        //			}
        //			Cluster c = getParentApiInstance().clusterInformation(id);
        //			for (ClusterStatus status: statuses) {
        //				if (c.getStatus() == status)
        //					break statusWait;
        //			}
        //			if (timeout != null && System.currentTimeMillis() - timeout*1000 > start)
        //				throw new XplentyAPIException("Timeout occurred while waiting for required cluster status");
        //		}
        //	}


    }
}