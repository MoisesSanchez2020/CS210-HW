using System;

class Program
{
    static void Main(string[] args)
{
    Job job1 = new Job();
    job1.JobTitle = "Software Engineer";
    job1.Company = "IDT Corp";
    job1.StartDate = "2002";
    job1.EndDate = "2023";

    Job job2 = new Job();
    job2.JobTitle = "Manager";
    job2.Company = "Apple";
    job2.StartDate = "2022";
    job2.EndDate = "2023";

    Console.WriteLine(job1.Company);
    Console.WriteLine(job2.Company);

    Resume myResume = new Resume();
    myResume.Name = "Moises Sanchez";
    myResume.Jobs.Add(job1);
    myResume.Jobs.Add(job2);

    Console.WriteLine(myResume.Jobs[0].JobTitle);

    myResume.Display();
}

}