using Newtonsoft.Json;
using XplentyApi.Exceptions;

namespace XplentyApi.Requests
{
    public abstract class XplentyRequest<T> : IXplentyRequest<T>
    {
        private string method = "POST";

        public virtual string Name { get; set; }
        public virtual string HttpMethod { get { return method; } set { method = value; } }
        public virtual string Endpoint { get; set; }
        public virtual bool HasBody { get; set; }
        public virtual string Body { get; set; }

        public virtual T GetResponse(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (System.Exception e)
            {
                throw new XplentyApiException(string.Format("Failed Parsing response object type={0}",typeof(T).Name), e);
            }            
        }
    }
}
