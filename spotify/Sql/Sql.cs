using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace spotify.Sql
{
    public class Sql
    {
        const string connectionString = "Server=CA-R214-PC03\\SQLEXPRESS;Database=Spotify;Trusted_Connection=True;";
        public static DataTable ExecuteQuery(string query)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int Execute(string query)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand cmd = new SqlCommand(query, con);
            return cmd.ExecuteNonQuery();
        }
        
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.Default.GetBytes(password)));
        }
    }
}
