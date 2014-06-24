namespace XplentyApi.Exceptions
{
    public class XplentyUnAuthorizedException : XplentyApiException
    {
        public string AccountName { get; set; }

        public string ApiKey { get; set; }

        public string Host { get; set; }
        
        
        public XplentyUnAuthorizedException(string accountName, string apiKey, string host) : 
            base(string.Format("Authentication against host={0} failed. AccountName={1}, ApiKey={2}",host,accountName,apiKey))
        {
            AccountName = accountName;
            ApiKey = apiKey;
            Host = host;
        }
    }
}