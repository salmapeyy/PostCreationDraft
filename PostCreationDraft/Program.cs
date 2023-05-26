using System;
using System.Collections.Generic;

class Post
{
	public string Content { get; set; }
	public DateTime DateTimePosted { get; set; }
}

class Program
{
	static List<Post> posts = new List<Post>();

	static void Main(string[] args)
	{
		bool exit = false;

		while (!exit)
		{
			Console.WriteLine("Post Management System");
			Console.WriteLine("1. Create a post");
			Console.WriteLine("2. Edit a post");
			Console.WriteLine("3. Want to Delete a Post");
			Console.WriteLine("4. List all posts");
			Console.WriteLine("5. Exit");
			Console.Write("Select an option: ");

			string option = Console.ReadLine();
			Console.WriteLine();

			switch (option)
			{
				case "1":
					CreatePost();
					break;
				case "2":
					EditPost();
					break;
				case "3":
					DeletePost();
					break;
				case "4":
					ListPosts();
					break;
				case "5":
					exit = true;
					break;
				default:
					Console.WriteLine("Invalid option. Please try again.");
					break;
			}

			Console.WriteLine();
		}
	}

	static void CreatePost()
	{
		Console.WriteLine("Creating a new post");

		Console.Write("Enter post content: ");
		string content = Console.ReadLine();

		DateTime dateTimePosted = DateTime.Now;

		Post post = new Post
		{
			Content = content,
			DateTimePosted = dateTimePosted
		};

		posts.Add(post);

		Console.WriteLine("Post created successfully!");
	}

	static void EditPost()
	{
		Console.WriteLine("Editing a post");

		ListPosts();

		Console.Write("Enter the index of the post to edit: ");
		int index = int.Parse(Console.ReadLine());

		if (index >= 0 && index < posts.Count)
		{
			Console.Write("Enter new post content: ");
			string content = Console.ReadLine();

			posts[index].Content = content;

			Console.WriteLine("Post edited successfully!");
		}
		else
		{
			Console.WriteLine("Invalid post index.");
		}
	}

	static void DeletePost()
	{
		Console.WriteLine("Deleting a post");

		ListPosts();

		Console.Write("Enter the index of the post to delete: ");
		int index = int.Parse(Console.ReadLine());

		if (index >= 0 && index < posts.Count)
		{
			posts.RemoveAt(index);

			Console.WriteLine("Post deleted successfully!");
		}
		else
		{
			Console.WriteLine("Invalid post index.");
		}
	}

	static void ListPosts()
	{
		Console.WriteLine("List of posts:");

		if (posts.Count == 0)
		{
			Console.WriteLine("No posts available.");
		}
		else
		{
			for (int i = 0; i < posts.Count; i++)
			{
				Console.WriteLine($"Post {i + 1}");
				Console.WriteLine($"Content: {posts[i].Content}");
				Console.WriteLine($"Posted on: {posts[i].DateTimePosted}");
				Console.WriteLine();
			}
		}
	}
}
