using System.Net.Http;

namespace BaseClientProject.Authentication
{
    public interface IClientAuthentication
    {
        HttpClient GetAuthenticatedClient();
    }
}
