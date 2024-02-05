



using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

adoDotNetExample.Read();
adoDotNetExample.Edit(1);
adoDotNetExample.Create("title test","author test","content test");
adoDotNetExample.Delete(2);
adoDotNetExample.Update(3, "title testing", "author testing", "content testing");