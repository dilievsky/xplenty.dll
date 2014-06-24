using XplentyApi.Requests;

namespace XplentyApi.Connectors
{
    public interface IConnector
    {
        string AccountName { get; set; }

        string ApiKey { get; set; }

        string Host { get; set; }

        string Protocol { get; set; }
        
        T SendRequest<T>(IXplentyRequest<T> xplentyRequest);
    }
}