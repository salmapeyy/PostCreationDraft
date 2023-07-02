using System;

namespace MODELS
{
    public class Post
    {
        public int PostNumber { get; set; }
        public string Content { get; set; }
        public DateTime DateTimePosted { get; set; }

        public string StudentNumber { get; set; }

        //public Post(int postNumber, string content)
        //{
        //    PostNumber = postNumber;
        //    Content = content;
        //    DateTimePosted = DateTime.Now;
        //}
    }
}
