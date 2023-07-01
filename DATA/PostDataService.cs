using MODELS;
using System.Collections.Generic;

namespace DATA
{
    public class PostDataService
    {

        SqlData sqlData = new SqlData();
        public List<Post> GetAllPosts()
        {
            return sqlData.GetPosts();
        }

        public int CreatePost(Post post)
        {
            return sqlData.CreatePost(post);
            
        }

    }
}
