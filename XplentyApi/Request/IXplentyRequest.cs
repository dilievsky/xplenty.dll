namespace XplentyApi.Request
{
    public interface IXplentyRequest<out T>
    {

        string Name { get; }

        string HttpMethod { get;}

        /**
         * Path and query parameters of a URL.
         * @return The path and query parameters as a String.
         */
        //Http.MediaType getResponseType();

        string Endpoint { get; }

        bool HasBody { get; }

        string Body { get; }

        T GetResponse(string data);
    }
}
