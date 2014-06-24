using System.Net;

namespace XplentyApi.Exceptions
{
    public class XplentyBadRequestException : XplentyApiException
    {
        public XplentyBadRequestException(HttpStatusCode statusCode, string name, string endpoint) : 
            base(string.Format("A request ({0}) to the end point = {1} got the response = {2}",name,endpoint,statusCode.ToString()))
        {
            
        }

        public XplentyBadRequestException(string message) : base(message)
        {

        }
    }
}