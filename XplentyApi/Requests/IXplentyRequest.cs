namespace XplentyApi.Requests
{
    public interface IXplentyRequest<out T>
    {

        string Name { get; }

        string HttpMethod { get;}

        string Endpoint { get; }

        bool HasBody { get; }

        string Body { get; }

        T GetResponse(string data);
    }
}
