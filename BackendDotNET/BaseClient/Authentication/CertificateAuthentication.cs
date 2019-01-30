using System;
using System.Net.Http;

namespace BaseClientProject.Authentication
{
    public class CertificateAuthentication : IClientAuthentication
    {
        public HttpClient GetAuthenticatedClient()
        {
            throw new NotImplementedException();
        }
    }
}
