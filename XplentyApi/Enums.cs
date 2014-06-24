using System.Runtime.Serialization;

namespace XplentyApi
{
    [DataContract]
	public enum ClusterType
	{
        [EnumMember(Value = "production")]
		Production = 0,
        [EnumMember(Value = "sandbox")]
		Sandbox 
	}

    [DataContract]
    public enum ClusterStatus
    {
        [EnumMember(Value = "idle")]
        Idle,
        [EnumMember(Value = "pending")]
        Pending,
		[EnumMember(Value = "error")]
		Error,
        [EnumMember(Value = "creating")]
		Creating,
        [EnumMember(Value = "available")]
		Available,
        [EnumMember(Value = "scaling")]
		Scaling,
        [EnumMember(Value = "pending_terminate")]
		PendingTerminate,
        [EnumMember(Value = "terminating")]
		Terminating,
        [EnumMember(Value = "terminated")]
		Terminated	
	}

    [DataContract]
    public enum JobStatus
    {
        [EnumMember(Value = "idle")]
        Idle,
        [EnumMember(Value = "stopped")]
		Stopped,
        [EnumMember(Value = "completed")]
		Completed,
        [EnumMember(Value = "pending")]
		Pending,
        [EnumMember(Value = "failed")]
		Failed,
        [EnumMember(Value = "running")]
		Running,
        [EnumMember(Value = "pending_stoppage")]
		PendingStoppage,
        [EnumMember(Value = "stopping")]
		Stopping		
    }
}
