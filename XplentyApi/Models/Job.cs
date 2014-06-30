using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XplentyApi.Models
{
	public class Job : XplentyObject
	{
		[JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
		public JobStatus Status { get; set; }

		[JsonProperty(PropertyName = "variables")]
		public IDictionary<string, string> Variables { get; set; }
	   
		[JsonProperty(PropertyName = "progress")]
		public double Progress { get; set; }

		[JsonProperty(PropertyName = "outputs_count")]
		public int OutputsCount { get; set; }

		[JsonProperty(PropertyName = "outputs")]
		public IList<IDictionary<string, string>> Outputs { get; set; }
		
		[JsonProperty(PropertyName = "started_at")]
		public DateTime? StartedAt { get; set; }
		
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
		
		[JsonProperty(PropertyName = "runtime_in_seconds")]
		public long RuntimeInSeconds { get; set; }

	}
}