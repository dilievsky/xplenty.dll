using System;
using System.IO;
using System.Net;
using System.Text;
using XplentyApi.Exceptions;
using XplentyApi.Request;

namespace XplentyApi
{
    public class WebConnectivity
    {
        private const string ApiPath = "api";

        protected readonly string AccountName;
        protected readonly string ApiKey;
        protected string protocol = "https";
         
        protected string Host = "api.xplenty.com";
        
        public Version ApiVersion { get; set; }
        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        public WebConnectivity(string accountName, string apiKey)
        {
            AccountName = accountName;
            ApiKey = apiKey;      
        }

        public WebConnectivity(string accountName, string apiKey, string host, string protocol) : this(accountName, apiKey)
        {
            Host = host;
            Protocol = protocol;
        }

        private void AddAuthorization(WebRequest request)
        {
            var credentialsByte = Encoding.UTF8.GetBytes(string.Format("{0}:{1}",ApiKey,string.Empty));
            var credentials = Convert.ToBase64String(credentialsByte);
            request.Headers.Add("Authorization", "Basic " + credentials);
        }

        private HttpWebRequest CreateRequest(string method, Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = 30 * 1000 /* 30 seconds */;
            request.Method = method;
            request.MediaType = "application/vnd.xplenty+json";
            request.ContentType = "application/json";
            request.Accept = "application/vnd.xplenty+json";

            AddAuthorization(request);

            return request;
        }

        private Uri BuildEndPointUri(string endPoint)
        {
            var uriBuilder = new UriBuilder
                {
                    Scheme = protocol,
                    Host = string.Format("{0}/{1}/{2}/{3}", Host, AccountName, ApiPath, endPoint)
                };

            return uriBuilder.Uri;
        }


        protected T SendRequest<T>(IXplentyRequest<T> xplentyRequest)
        {
            var uri = BuildEndPointUri(xplentyRequest.Endpoint);
            var webRequest = CreateRequest(xplentyRequest.HttpMethod, uri);

            AddData(webRequest, xplentyRequest);

            var responseData = ReadData<T>((HttpWebResponse) webRequest.GetResponse());

            return xplentyRequest.GetResponse(responseData);
        }

        private static string ReadData<T>(HttpWebResponse response)
        {
            using (var readStream = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                var result = readStream.ReadToEnd();
                return result;
            }
        }

        private static void AddData<T>(WebRequest webRequest, IXplentyRequest<T> xplentyRequest)
        {
            using (var requestStream = webRequest.GetRequestStream())
            {
                try
                {
                    if (!xplentyRequest.HasBody)
                    {
                        return;
                    }

                    var t = xplentyRequest.Body;

                    var data = Encoding.ASCII.GetBytes(t);

                    requestStream.Write(data, 0, xplentyRequest.Body.Length);

                }
                catch (Exception e)
                {
                    throw new XplentyApiException("Failed while writing to request stream", e);
                }
            }
        }
    }
}
