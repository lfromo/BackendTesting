using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace BaseClientProject
{
    public class EndpointJsonResponse<T> : EndpointResponse<T>
    {
        public EndpointJsonResponse(HttpResponseMessage response) : base(response) { }

        public override T GetResponseContent()
        {
            JsonSerializer _serializer = new JsonSerializer();
            JsonTextReader _reader = new JsonTextReader(new StringReader(GetResponseRawBodyContent()));
            return _serializer.Deserialize<T>(_reader);
        }
    }
}
