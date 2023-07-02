using DATA;
using MODELS;
using System.Collections.Generic;

namespace RULES
{
    public class PostRules
    {
        PostDataService dataService = new PostDataService();
        public List<Post> ViewAllPosts()
        {
            return dataService.GetAllPosts();
        }

        public List<Post> ViewAllPostPerStudent(string studentNumber)
        {
            return null;
        }

        public int CreatePost(Post post)
        {
            // add validation as needed
            return dataService.CreatePost(post);
        }

        public void EditPost(Post oldPost, Post newPost)
        {

        }

        public void DeletePost(Post post)
        {

        }
    }
}
