





















// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

#region for read
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019";
stringBuilder.InitialCatalog = "TestDb";
stringBuilder.UserID = "sa";
stringBuilder.Password="sasa"; 

SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);

sqlConnection.Open();
string Queryable = "select * from tbl_Blog";
SqlCommand sqlCommand = new SqlCommand(Queryable, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
DataTable dt = new DataTable();
adapter.Fill(dt);
sqlConnection.Close();

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["blogid"]);
    Console.WriteLine(dr[1]);
    Console.WriteLine(dr[2]);
    Console.WriteLine(dr["blogcontent"]);
    Console.WriteLine();
}
#endregion