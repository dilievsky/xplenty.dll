using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XplentyApi.Model
{
	public class Job : XplentyObject
	{
		[JsonProperty(PropertyName = "status")]
		public JobStatus Status { get; set; }

		[JsonProperty(PropertyName = "variables")]
		public IDictionary<string, string> Variables { get; set; }
	   
		[JsonProperty(PropertyName = "progress")]
		public double Progress { get; set; }

		[JsonProperty(PropertyName = "outputs_count")]
		public int OutputsCount { get; set; }

		[JsonProperty(PropertyName = "outputs")]
		public IList<string> Outputs { get; set; }
		
		[JsonProperty(PropertyName = "started_at")]
		public DateTime? StartedAt { get; set; }
		
		[JsonProperty(PropertyName = "created_at")]
		public DateTime? CreatedAt { get; set; }
		
		[JsonProperty(PropertyName = "completed_at")]
		public DateTime? CompletedAt { get; set; }
		
		[JsonProperty(PropertyName = "failed_at")]
		public DateTime? FailedAt { get; set; }
		
		[JsonProperty(PropertyName = "upDateTimed_at")]
		public DateTime? UpdatedAt { get; set; }
		
		[JsonProperty(PropertyName = "cluster_id")]
		public long ClusterId { get; set; }
		
		[JsonProperty(PropertyName = "package_id")]
		public long PackageId { get; set; }
		
		[JsonProperty(PropertyName = "errors")]
		public string Errors { get; set; }
		
		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
		
		[JsonProperty(PropertyName = "runtime_in_seconds")]
		public long RuntimeInSeconds { get; set; }



//
//	    /**
//	     * Shorthand method for {@code waitForStatus(null, JobStatus...)} Will wait forever until the required status is received.
//	     * @param statuses see {@link #waitForStatus(Long, JobStatus...)}
//	     */
//	    public void waitForStatus(JobStatus... statuses) {
//		    waitForStatus(null, statuses);
//	    }
//	
//	    /**
//	     * Blocks execution until required status is received from the Xplenty server, or until timeout occurs.
//	     * @param timeout time in seconds before terminating the wait, {@code null} to wait forever
//	     * @param statuses list of statuses to wait for, see {@link JobStatus} for the list of supported statuses
//	     */
//	    public void waitForStatus(Long timeout, JobStatus... statuses) {
//		    if (getParentApiInstance() == null)
//			    throw new XplentyAPIException("The parent API instance is not set");
//		    long start = System.currentTimeMillis();
//		    statusWait:
//		    while (true) {
//			    try {
//				    Thread.sleep(XplentyObject.StatusRefreshInterval);
//			    } catch (InterruptedException e) {
//				    throw new XplentyAPIException("Error sleeping", e);
//			    }
//			    Job c = getParentApiInstance().jobInformation(id);
//			    for (JobStatus status: statuses) {
//				    if (c.getStatus() == status)
//					    break statusWait;
//			    }
//			    if (System.currentTimeMillis() - timeout*1000 > start)
//				    throw new XplentyAPIException("Timeout occurred while waiting for required job status");
//		    }
//	    }


	}
}