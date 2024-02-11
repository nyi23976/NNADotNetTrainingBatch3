using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EFCoreExamples
{
    public class AppDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-JRQ534H\\MSSQLSERVER2019",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> blogs { get; set; }
    }
}
