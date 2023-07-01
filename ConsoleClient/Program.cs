using MODELS;
using RULES;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PostRules postRules = new PostRules();

            //Console.Write("Enter student number: ");
            //string studentNumber = Console.ReadLine();

            //Console.WriteLine("Enter your post:");
            //string content = Console.ReadLine();

            //Post newpost = new Post
            //{
            //    PostNumber = 3, //create auto increment logic
            //    StudentNumber = studentNumber,
            //    Content = content,
            //    DateTimePosted = DateTime.Now
            //};

            //var result = postRules.CreatePost(newpost);

            //if (result > 0 )
            //{
            //    Console.WriteLine("Successfully posted content");
            //}
            //else
            //{
            //    Console.WriteLine("failed");
            //}

            //Capability to View All Post

            List<Post> posts = new List<Post>();

            posts = postRules.ViewAllPosts();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Number: {post.PostNumber}");
                Console.WriteLine($"Post Content: {post.Content}");
                Console.WriteLine($"Student Number: {post.StudentNumber}");
                Console.WriteLine($"Date Posted: {post.DateTimePosted}");
            }


            //Capability to view posts of specific students
            //capability to create post
            //capability to update post
            //capability to delete post


        }
    }
}
