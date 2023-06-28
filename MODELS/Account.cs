using System;

namespace MODELS
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }

        public Account(string username, string password, string name, string studentNumber)
        {
            Username = username;
            Password = password;
            Name = name;
            StudentNumber = studentNumber;
        }
    }
}
