using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    internal class SqlData
    {
        static string connectionString
       = "Data Source =localhost; Initial Catalog = PUPHubPosts; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPPoints;User Id=sa;Password=indaleenq727!;";
        static SqlConnection sqlConnection;

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Post> GetPosts()
        {
            var selectStatement = "SELECT PostNumber, StudentNumber, PostContent, DateTimePosted FROM Post";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var posts = new List<Post>();

            while (reader.Read())
            {
                posts.Add(new Post
                {
                    PostNumber = Convert.ToInt16(reader["PostNumber"].ToString()),
                    StudentNumber = reader["StudentNumber"].ToString(),
                    Content = reader["PostContent"].ToString(),
                    DateTimePosted = DateTime.Now
                });
            }

            sqlConnection.Close();
            return posts;
        }

        public int CreatePost(Post post)
        {
            int success;
            var insertStatement = "INSERT INTO Post VALUES (@PostNumber, @StudentNumber, @PostContent,  @DateTimePosted)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@PostNumber", post.PostNumber);
            insertCommand.Parameters.AddWithValue("@StudentNumber", post.StudentNumber);
            insertCommand.Parameters.AddWithValue("@PostContent", post.Content);
            insertCommand.Parameters.AddWithValue("@DateTimePosted", post.DateTimePosted);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}
