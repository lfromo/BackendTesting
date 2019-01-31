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
        public void SuperCompleteButDirtyTestMethod()
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


            var putMethodPost = new Post()
            {
                userId = 54,
                title = "PutMethodTitle",
                body = "PutMethodBody"
            };
            


            var patchMethodPost = new Post()
            {
                userId = 21,
                title = "PatchMethodTitle",
                body = "PatchMethodBody"
            };



            var todos = _client.GetToDos();
            Assert.AreEqual(HttpStatusCode.OK, todos.GetResponseStatusCode());
            Assert.IsTrue(todos.GetResponseContent().Count > 0);


            var albums = _client.GetAlbums();
            Assert.AreEqual(HttpStatusCode.OK, albums.GetResponseStatusCode());
            Assert.IsTrue(albums.GetResponseContent().Count > 0);

            Assert.AreEqual(HttpStatusCode.OK, posts.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.OK, users.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.OK, getPostFromUser.GetResponseStatusCode());
            Assert.AreEqual(HttpStatusCode.Created, addPost.GetResponseStatusCode());
            

            var responseAddOrPost = addPost.GetResponseContent();
            Assert.AreEqual(newPost.userId, responseAddOrPost.userId);
            Assert.AreEqual(101, responseAddOrPost.id);

            var putPost = _client.UpdatePost(3, putMethodPost);
            Assert.AreEqual(HttpStatusCode.OK, putPost.GetResponseStatusCode());
            var responsePut = putPost.GetResponseContent();
            Assert.AreEqual(3, responsePut.id);
            Assert.AreEqual(putMethodPost.userId, responsePut.userId);
            Assert.AreEqual(putMethodPost.body, responsePut.body);
            Assert.AreEqual(putMethodPost.title, responsePut.title);

            var photos = _client.GetPhotos().GetResponseContent();
            Assert.IsFalse(photos.Count == 0);

            var patchPost = _client.UpdatePost2(7, patchMethodPost);
            Assert.AreEqual(HttpStatusCode.OK, patchPost.GetResponseStatusCode());
            var responsePatch = patchPost.GetResponseContent();
            Assert.AreEqual(patchMethodPost.userId, responsePatch.userId);
            Assert.AreEqual(patchMethodPost.body, responsePatch.body);
            Assert.AreEqual(patchMethodPost.title, responsePatch.title);
            Assert.AreEqual(7, responsePatch.id); // Its going to fail. A Bug? Check the requirements first! xd

        }
    }
}
