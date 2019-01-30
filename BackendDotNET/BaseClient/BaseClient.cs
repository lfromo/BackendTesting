using BaseClientProject.Authentication;
using System.Net.Http;

namespace BaseClientProject
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _client;
       
        public BaseClient(IClientAuthentication auth, string baseAddress)
        {
            _client = auth.GetAuthenticatedClient();
            _client.BaseAddress = new System.Uri(baseAddress);
        }

        public BaseClient(string baseAddress)
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri(baseAddress)
            };
        }

    }
}
