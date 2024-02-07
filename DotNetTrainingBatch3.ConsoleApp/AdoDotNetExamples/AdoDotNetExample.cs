using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sasa";

            SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"SELECT [BlogId]
                                   ,[BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent]
                               FROM [dbo].[Tbl_Blog]";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["blogid"]);
                Console.WriteLine(dr["blogTitle"]);
                Console.WriteLine(dr["blogAuthor"]);
                Console.WriteLine(dr["blogContent"]);
                Console.WriteLine();
            }
        }
       
        public void Edit(int id)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sasa";

            SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"SELECT [BlogId]
                                   ,[BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent]
                               FROM [dbo].[Tbl_Blog] where BlogId=@BlogId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Title..." + dr["BlogTitle"]);
            Console.WriteLine("Author..." + dr["BlogAuthor"]);
            Console.WriteLine("Content..." + dr["BlogContent"]);
        }
    
        public void Create(string title,string author,string content)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sasa";
            SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"INSERT INTO[dbo].[Tbl_Blog]
                                             ([BlogTitle]
                                             ,[BlogAuthor]
                                             ,[BlogContent])
                                              VALUES
                                             (@BlogTitle
                                             ,@BlogAuthor
                                             ,@BlogContent)";
            SqlCommand sqlCommand = new SqlCommand( query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@BlogTitle", title);
            sqlCommand.Parameters.AddWithValue("@BlogAuthor", author);
            sqlCommand.Parameters.AddWithValue("@BlogContent", content);
            int result= sqlCommand.ExecuteNonQuery();
            sqlConnection.Close() ;
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine();
            Console.WriteLine(message);

        }
      
        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sasa";

            SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
                                SET [BlogTitle] = @BlogTitle
                                   ,[BlogAuthor] = @BlogAuthor
                                   ,[BlogContent] = @BlogContent
                              WHERE BlogId = @BlogId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@BlogId", id);
            sqlCommand.Parameters.AddWithValue("@BlogTitle", title);
            sqlCommand.Parameters.AddWithValue("@BlogAuthor", author);
            sqlCommand.Parameters.AddWithValue("@BlogContent", content);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine();
            Console.WriteLine(message);
        }
      
        public void Delete(int id)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
            stringBuilder.InitialCatalog = "TestDb";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "sasa";

            SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"DELETE FROM[dbo].[Tbl_Blog]
                                  WHERE BlogId=@BlodId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@BlodId", id);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}
