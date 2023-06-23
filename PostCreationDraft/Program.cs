using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;

class Account	//MODELS LAYER
{
	public string Username { get; set; }
	public string Password { get; set; }
	public string Name { get; set; }
	public string StudentNumber { get; set; }
	public string AdminNumber { get; set; }

	public Account(string username, string password, string name, string studentNumber, string adminNumber)	//models
	{
		Username = username;
		Password = password;
		Name = name;
		StudentNumber = studentNumber;
		AdminNumber = adminNumber;
	}
}

class Post	//model
{
	public int PostNumber { get; set; }
	public string Content { get; set; }
	public DateTime DateTimePosted { get; set; }

	public Post(int postNumber, string content)		//model
	{
		PostNumber = postNumber;
		Content = content;
		DateTimePosted = DateTime.Now;
	}
}

class Program
{
	static List<Account> accounts = new List<Account>();	//data layer
	static List<Post> posts = new List<Post>();
	static string loggedInUser = null;

	static void Main(string[] args)
	{

		bool exit = false;

		while (!exit)		//business layer
		{
			if (loggedInUser == null)
			{
				ShowLoginMenu();
				string option = Console.ReadLine();
				Console.WriteLine();

				switch (option)
				{
					case "0": AdminAcc();
						break;
					case "1":
						Login();
						break;
					case "2":
						CreateAccount();
						break;
					case "3":
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
			else
			{
				ShowMenu();

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
						ShowAccountDetails();
						break;
					case "6":
						Logout();
						break;
					case "7":
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}

			Console.WriteLine();
			Console.WriteLine("Press Enter to continue...");
			Console.ReadLine();
			Console.Clear();
		}
	}

	static void ShowLoginMenu()		//UI
	{
		Console.WriteLine("PUP HUB BULLETIN BOARD");
		Console.WriteLine("0. Login as Admin");
		Console.WriteLine("1. Login");
		Console.WriteLine("2. Create an account");
		Console.WriteLine("3. Exit");
		Console.Write("Select an option: ");
	}

	static void ShowMenu()		//UI
	{
		Console.WriteLine($"Welcome, {loggedInUser}!");
		Console.WriteLine("1. Create a post");
		Console.WriteLine("2. Edit a post");
		Console.WriteLine("3. Delete a post");
		Console.WriteLine("4. List all posts");
		Console.WriteLine("5. Show account details");
		Console.WriteLine("6. Logout");
		Console.WriteLine("7. Exit");
		Console.Write("Select an option: ");
	}

	static void CreateAccount()		
	{
		Console.WriteLine("Creating a new account");	//BUSINESS

		Console.Write("Enter a username: ");
		string username = Console.ReadLine();

		if (IsUsernameTaken(username))		//DATA 
		{
			Console.WriteLine("Username already taken. Please choose a different username.");
			return;
		}

		Console.Write("Enter a password: ");		//DATA
		string password = Console.ReadLine();

		Console.Write("Enter your name(Last Name, First Name, MI): ");
		string name = Console.ReadLine();

		Console.Write("Enter your student number: ");
		string studentNumber = Console.ReadLine();

		Account account = new Account(username, password, name, studentNumber);
		accounts.Add(account);

		Console.WriteLine("Account created successfully!");		
		Console.WriteLine("Account Details:");
		Console.WriteLine($"Username: {account.Username}");
		Console.WriteLine($"Name: {account.Name}");
		Console.WriteLine($"Student Number: {account.StudentNumber}");
	}

	static bool IsUsernameTaken(string username)	//BUSINESS
	{
		foreach (var account in accounts)
		{
			if (account.Username == username)
			{
				return true;
			}
		}

		return false;
	}

	static void Login()		
	{
		Console.Write("Enter your username: ");
		string username = Console.ReadLine();

		Console.Write("Enter your password: ");
		string password = Console.ReadLine();

		Account account = GetAccount(username);		//DATA

		if (account != null && account.Password == password)
		{
			loggedInUser = username;
			Console.WriteLine("Login successful!");
		}
		else
		{
			Console.WriteLine("Invalid username or password.");
		}
	}

	static Account GetAccount(string username)		//BUSINESS
	{
		foreach (var account in accounts)
		{
			if (account.Username == username)
			{
				return account;
			}
		}

		return null;
	}

	static void Logout()	//BUSINESS
	{
		loggedInUser = null;
		Console.WriteLine("Logged out successfully!");
	}

	static void CreatePost()	//DATA
	{
		Console.WriteLine("Creating a new post");

		Console.Write("Enter post content: ");
		string content = Console.ReadLine();

		int postNumber = GetNextPostNumber();

		Post post = new Post(postNumber, content);
		posts.Add(post);

		Console.WriteLine("Post created successfully!");
	}

	static int GetNextPostNumber()		//BUSINESS
	{
		if (posts.Count > 0)
		{
			return posts[posts.Count - 1].PostNumber + 1;
		}

		return 1;
	}

	static void EditPost()
	{
		Console.WriteLine("Editing a post");

		ListPosts();

		Console.Write("Enter the number of the post to edit: ");
		int postNumber = int.Parse(Console.ReadLine());

		Post post = GetPostByNumber(postNumber);

		if (post != null)	//BUSINESS
		{
			Console.Write("Enter new post content: ");
			string newContent = Console.ReadLine();

			post.Content = newContent;

			Console.WriteLine("Post edited successfully!");
		}
		else
		{
			Console.WriteLine("Post not found.");
		}
	}

	static void DeletePost()
	{
		Console.WriteLine("Deleting a post");

		ListPosts();

		Console.Write("Enter the number of the post to delete: ");
		int postNumber = int.Parse(Console.ReadLine());

		Post post = GetPostByNumber(postNumber);	

		if (post != null)	//BUSINESS
		{
			posts.Remove(post);

			Console.WriteLine("Post deleted successfully!");
		}
		else
		{
			Console.WriteLine("Post not found.");
		}
	}

	static void ListPosts()
	{
		Console.WriteLine("List of posts:");

		if (posts.Count == 0)	//BUSINESS
		{
			Console.WriteLine("No posts available.");
		}
		else
		{
			foreach (var post in posts)
			{
				Console.WriteLine($"Post  {post.PostNumber}");
				Console.WriteLine($"Content: {post.Content}");
				Console.WriteLine($"Posted on: {post.DateTimePosted}");
				Console.WriteLine();
			}
		}
	}

	static Post GetPostByNumber(int postNumber)
	{
		foreach (var post in posts)		//BUSINESS
		{
			if (post.PostNumber == postNumber)
			{
				return post;
			}
		}

		return null;
	}

	static void ShowAccountDetails()
	{
		Account account = GetAccount(loggedInUser);

		if (account != null)	//BUSINES
		{
			Console.WriteLine("Account Details:");
			Console.WriteLine($"Username: {account.Username}");
			Console.WriteLine($"Name: {account.Name}");
			Console.WriteLine($"Student Number: {account.StudentNumber}");
		}
		else
		{
			Console.WriteLine("Account not found.");
		}
	}

	class AdminAccess
	{
		public string AdminNumber;
		public string Password;

		public AdminAccess(string AdminNumber, string Password)
		{
			this.AdminNumber = AdminNumber;
			this.Password = Password;
			
		}
		
		public void AdminAcc()
		{
			Console.WriteLine("Enter Admin Number: ");
			Console.ReadLine();
			Console.WriteLine("Enter Password: ");
			Console.ReadLine();
			if (AdminNumber == "Ad123" && Password == "222")
			{
				Console.WriteLine("SUCCESSFULLY LOGGED IN!");
			
			}
			else
			{
				Console.WriteLine("INVALID DATA PLEASE TRY AGAIN!");
				ShowLoginMenu();
			}

			
		} 

		static void ShowAdminMenu()
		{
			Console.WriteLine("Lis");
		}
		





	}
}
