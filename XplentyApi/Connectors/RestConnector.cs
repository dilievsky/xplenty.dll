using System;
using System.IO;
using System.Net;
using System.Text;
using XplentyApi.Exceptions;
using XplentyApi.Requests;

namespace XplentyApi.Connectors
{
    public class RestConnector : IConnector
    {
        private const string ApiPath = "api";
        private string host = "api.xplenty.com";
        private string protocol = "https";

        public string AccountName { get; set; }
        public string ApiKey { get; set; }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        public RestConnector(string accountName, string apiKey)
        {
            AccountName = accountName;
            ApiKey = apiKey;      
        }

        public RestConnector(string accountName, string apiKey, string host, string protocol) : this(accountName, apiKey)
        {
            this.host = host;
            this.protocol = protocol;
        }

        public T SendRequest<T>(IXplentyRequest<T> xplentyRequest)
        {
            ValidateRequest(xplentyRequest);
            
            var uri = BuildEndPointUri(xplentyRequest.Endpoint);

            var webRequest = CreateRequest(xplentyRequest, uri);

            var webResponse = webRequest.GetResponse();

            ValidateResponse((HttpWebResponse)webResponse,xplentyRequest);

            return xplentyRequest.GetResponse(ReadData(webResponse));
        }

        #region private

        private void AddAuthorization(WebRequest request)
        {
            var credentialsByte = Encoding.UTF8.GetBytes(string.Format("{0}:{1}",ApiKey,string.Empty));
            var credentials = Convert.ToBase64String(credentialsByte);
            request.Headers.Add("Authorization", "Basic " + credentials);
        }

        private HttpWebRequest CreateRequest<T>(IXplentyRequest<T> xplentyRequest, Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = 30 * 1000 /* 30 seconds */;
            request.Method = xplentyRequest.HttpMethod;
            request.MediaType = "application/vnd.xplenty+json";
            request.ContentType = "application/json";
            request.Accept = "application/vnd.xplenty+json";

            AddAuthorization(request);

            if (xplentyRequest.HttpMethod == "POST" && xplentyRequest.HasBody)
            {
                AddData(request, xplentyRequest);
            }

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

        private static string ReadData(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            if (responseStream == null)
            {
                return string.Empty;
            }

            try
            {
                using (var readStream = new StreamReader(responseStream, Encoding.ASCII))
                {
                    return readStream.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new XplentyApiException("Failed while reading data from response stream", e);
            }
        }

        private static void AddData<T>(WebRequest webRequest, IXplentyRequest<T> xplentyRequest)
        {
            using (var requestStream = webRequest.GetRequestStream())
            {
                try
                {
                    var data = Encoding.ASCII.GetBytes(xplentyRequest.Body);

                    requestStream.Write(data, 0, xplentyRequest.Body.Length);

                }
                catch (Exception e)
                {
                    throw new XplentyApiException("Failed while writing to request stream", e);
                }
            }
        }

        private void ValidateResponse<T>(HttpWebResponse webResponse, IXplentyRequest<T> request)
        {           
            switch (webResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NoContent:
                    return;
                case HttpStatusCode.Unauthorized:
                    throw new XplentyUnAuthorizedException(AccountName, ApiKey, Host);
                default:
                    throw new XplentyBadRequestException(webResponse.StatusCode, request.Name, request.Endpoint);
            }
        }

        private static void ValidateRequest<T>(IXplentyRequest<T> xplentyRequest)
        {
            if (string.IsNullOrEmpty(xplentyRequest.Endpoint))
            {
                throw new XplentyBadRequestException(string.Format("Request {0} has no end point",xplentyRequest.Name));
            }
        }

        #endregion
    }
}
