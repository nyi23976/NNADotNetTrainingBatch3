using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDBContext dbContext = new AppDBContext();
            List<BlogModel>lst = dbContext.blogs.ToList();
            foreach (BlogModel model in lst)
            {
                Console.WriteLine(model.BlogId);
                Console.WriteLine(model.BlogTitle);
                Console.WriteLine(model.BlogAuthor);
                Console.WriteLine(model.BlogContent);
                Console.WriteLine("____________________________");
            }
        }

        public void Edit(int id)
        {
            AppDBContext dbContext = new AppDBContext();
            BlogModel item = dbContext.blogs.FirstOrDefault(item=>item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine("_____________Edit Item_______________");
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("_____________Edit Item_______________");
        }
        public void Create(string title,string author,string content)
        {
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            AppDBContext appDBContext = new AppDBContext();
            appDBContext.blogs.Add(model);
            int result=appDBContext.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        public void Update(int id,string title,string author,string content) 
        {
        AppDBContext appDBContext=new AppDBContext();

            BlogModel item = appDBContext.blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = appDBContext.SaveChanges();
            string messge = result > 0 ? "Updating Successful" : "Updaing Fail";
            Console.WriteLine(messge);
        }
        public void Delete(int id)
        {
            AppDBContext appDBContext= new AppDBContext();
            BlogModel item=appDBContext.blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            appDBContext.Remove(item);
            int result = appDBContext.SaveChanges();

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
