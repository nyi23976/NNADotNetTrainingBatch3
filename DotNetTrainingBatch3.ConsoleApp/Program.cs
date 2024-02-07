using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Create("title test","author test","content test");
//adoDotNetExample.Delete(2);
//adoDotNetExample.Update(3, "title testing", "author testing", "content testing");


DapperExample dapperExample = new DapperExample();
dapperExample.Read();
Console.WriteLine("_____________finish read process_________");

dapperExample.Edit(1);
Console.WriteLine("_____________finish Edit process_________");

dapperExample.Create("Book", "Phay Myint", "Rich Dad and Poor Dad");
Console.WriteLine("_____________finish Create process_________");

dapperExample.Update(10, "Computer", "Laptop", "Dell");
Console.WriteLine("_____________finish Update process_________");

dapperExample.Delete(17);
Console.WriteLine("_____________finish Delete process_________");