using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
adoDotNetExample.Edit(1);
adoDotNetExample.Create("title test", "author test", "content test");
adoDotNetExample.Delete(2);
adoDotNetExample.Update(3, "title testing", "author testing", "content testing");


DapperExample dapperExample = new DapperExample();
dapperExample.Read();
dapperExample.Edit(1);
dapperExample.Create("Book", "Phay Myint", "Rich Dad and Poor Dad");
dapperExample.Update(10, "Computer", "Laptop", "Dell");
dapperExample.Delete(17);

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit(1);
eFCoreExample.Create("IT", "Computer", "Laptop");
eFCoreExample.Update(4, "AAAA", "BBB", "CCC");
eFCoreExample.Delete(15);