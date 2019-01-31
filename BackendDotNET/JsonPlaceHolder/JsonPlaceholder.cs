using BaseClientProject;
using JsonPlaceHolder.Models;
using JsonPlaceHolder.Models.Users;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http; //Do not remove this or the Web API extension won't show up for the HttpClient.
using System.Net.Http.Headers;

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

        public EndpointResponse<List<Comment>> GetCommentsFromPost(int postId)
        {
            var response = new EndpointJsonResponse<List<Comment>>(_client.GetAsync($"comments?postId={postId}").Result);
            return response;
        }

        public EndpointResponse<List<Comment>> GetCommentsFromPost2(int postId)
        {
            var response = new EndpointJsonResponse<List<Comment>>(_client.GetAsync($"posts/{postId}/comments").Result);
            return response;
        }
        
        public EndpointResponse<Post> AddPost(Post post)
        {
            var response = new EndpointJsonResponse<Post>(_client.PostAsJsonAsync("posts", post).Result);
            return response;
        }

        public EndpointResponse<Post> UpdatePost(int postId, Post post)
        {
            var response = new EndpointJsonResponse<Post>(_client.PutAsJsonAsync($"posts/{postId}", post).Result);
            return response;
        }

        public EndpointResponse<Post> UpdatePost2(int postId, Post post)
        {
            HttpRequestMessage _message = new HttpRequestMessage();
            _message.Content = new StringContent(JsonConvert.SerializeObject(post));
            _message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _message.Content.Headers.Add("leCustomHeader", "leValue");
            var response = new EndpointJsonResponse<Post>(_client.PatchAsync($"posts/{postId}", _message.Content).Result);
            return response;
        }

        public HttpResponseMessage DeletePost(int postId)
        {
            return _client.DeleteAsync($"posts/{postId}").Result;
        }


        public EndpointResponse<List<Photo>> GetPhotos()
        {
            return new EndpointJsonResponse<List<Photo>>(_client.GetAsync("photos").Result);
        }

        public EndpointResponse<List<Todo>> GetToDos()
        {
            return new EndpointJsonResponse<List<Todo>>(_client.GetAsync("todos").Result);
        }

        public EndpointResponse<List<Album>> GetAlbums()
        {
            return new EndpointJsonResponse<List<Album>>(_client.GetAsync("albums").Result);
        }



        //DON'T DO THIS IN PRACTICE!!!
        private static string GetBaseUrl() 
        {
            return "http://jsonplaceholder.typicode.com";
        }



    }
}
