using System;
using System.Collections.Generic;
using MODELS;

namespace DataLayer
{
    public class DataLayer
    {
        static List<Account> accounts = new List<Account>();
        static List<Post> posts = new List<Post>();
        public static string loggedInUser = null;
    }
}
