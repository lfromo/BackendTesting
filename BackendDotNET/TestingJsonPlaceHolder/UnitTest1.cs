using JsonPlaceHolder;
using JsonPlaceHolder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace TestingJsonPlaceHolder
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            JsonPlaceholderClient _client = new JsonPlaceholderClient();
            var posts = _client.GetPosts();
            var users = _client.GetUsers();
            var getPostFromUser = _client.GetPostsFromUser(1);

            Post newPost = new Post()
            {
                title = "TitleInter",
                body = "The new Body",
                userId = 3
            };
            
            var addPost = _client.AddPost(newPost);

            Assert.AreEqual(HttpStatusCode.OK, posts.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.OK, users.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.OK, getPostFromUser.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.Created, addPost.GetResponseStatusCode());

            var response = addPost.GetResponseContent();

            Assert.AreEqual(newPost.userId, response.userId);
            Assert.AreEqual(101, response.id);

        }
    }
}
