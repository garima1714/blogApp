using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace blogApp.Models
{
    public class DataAcessLayer
    {
        string connectionString = "Server=CYG365;Database=blogApp;User Id=sa;Password=P@ssword01;Trusted_Connection=true;";

        public IEnumerable<Post> GetAllPost()
        {
            List<Post> allPost = new List<Post>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("readPost", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Post post = new Post();

                    post.PostId = Convert.ToInt32(rdr["PostId"]);
                    post.PostData= rdr["PostData"].ToString();
                    post.PostHeading= rdr["PostHeading"].ToString();
                    post.PostUrl= rdr["PostUrl"].ToString();
                    allPost.Add(post);
                }
                con.Close();
            }
            return allPost;
        }
        public void AddPost(Post post)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("addPost", con);
    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@postHeading", post.PostHeading);
                    cmd.Parameters.AddWithValue("@postData", post.PostData);
                    cmd.Parameters.AddWithValue("@postUrl", post.PostUrl);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        public void UpdatePost(Post post)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("updatePost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@postId", post.PostId);
                cmd.Parameters.AddWithValue("@postData", post.PostData);
                cmd.Parameters.AddWithValue("@postHeading", post.PostHeading);
                cmd.Parameters.AddWithValue("@postUrl", post.PostUrl);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeletePost(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deletePost", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@postId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Post GetPostData(int? id)
        {
            Post post = new Post();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM post WHERE postId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    post.PostId = Convert.ToInt32(rdr["PostId"]);
                    post.PostData= rdr["PostData"].ToString();
                    post.PostHeading= rdr["PostHeading"].ToString();
                    post.PostUrl = rdr["PostUrl"].ToString();
                }
            }
            return post;
        }

    }
}
