using System.Net;
using System.Net.Http;

namespace BaseClientProject
{
    public abstract class EndpointResponse<T>
    {
        protected readonly T _responseModel;
        private readonly HttpResponseMessage _clientResponse;

        public EndpointResponse(HttpResponseMessage response)
        {
            _clientResponse = response;
        }

        public HttpStatusCode GetResponseStatusCode()
        {
            return _clientResponse.StatusCode;
        }

        public string GetResponseRawBodyContent()
        {
            return _clientResponse.Content.ReadAsStringAsync().Result;
        }

        public abstract T GetResponseContent();
       
    }
}
