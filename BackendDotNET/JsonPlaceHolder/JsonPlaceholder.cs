using BaseClientProject;
using JsonPlaceHolder.Models;
using JsonPlaceHolder.Models.Users;
using System.Collections.Generic;
using System.Net.Http; //Do not remove this or the Web API extension won't show up for the HttpClient.

namespace JsonPlaceHolder
{
    public class JsonPlaceholderClient : BaseClient
    {
        public JsonPlaceholderClient() : base(GetBaseUrl()) { }


        public EndpointResponse<List<User>> GetUsers()
        {
            var response = new EndpointJsonResponse<List<User>>(_client.GetAsync("users").Result);
            return response;
        }

        public EndpointResponse<List<Post>> GetPosts()
        {
            var response = new EndpointJsonResponse<List<Post>>(_client.GetAsync("posts").Result);
            return response;
        }

        public EndpointResponse<List<Post>> GetPostsFromUser(int userId)
        {
            var response = new EndpointJsonResponse<List<Post>>(_client.GetAsync($"posts?userId={userId}").Result);
            return response;
        }

        public EndpointResponse<List<Post>> GetPost(int postId)
        {
            var response = new EndpointJsonResponse<List<Post>>(_client.GetAsync($"posts/{postId}").Result);
            return response;
        }

        public EndpointResponse<Post> AddPost(Post post)
        {
            var response = new EndpointJsonResponse<Post>(_client.PostAsJsonAsync("posts", post).Result);
            return response;
        }

        //DON'T DO THIS!!!
        private static string GetBaseUrl() 
        {
            return "http://jsonplaceholder.typicode.com";
        }



    }
}
