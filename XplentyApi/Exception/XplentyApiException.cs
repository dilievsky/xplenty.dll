using System;

namespace XplentyApi.Exceptions
{
    public class XplentyApiException : Exception
    {
        public XplentyApiException(string message, Exception exception) : base(message,exception)
        {
            
        }
    }
}