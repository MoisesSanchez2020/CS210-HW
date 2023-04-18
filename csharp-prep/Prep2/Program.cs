using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Write(" What is your grade percentage");
       string  percentage = Console.ReadLine();
       int scoreGrade = int.Parse(percentage);

         string symGrade = "";

        if (scoreGrade >= 90)
        {
            symGrade = "A";
        }

        else if (scoreGrade >= 80)
        {
            symGrade = "B";
        }

        else if (scoreGrade >= 70)
        {
            symGrade = "C";
        }

        else if (scoreGrade >= 60)
        {
            symGrade = "D";
        }

        else
        {
            symGrade = "F";
        }

        Console.WriteLine($"your grade is : {symGrade}");

        if (scoreGrade >= 70)
        {
            Console.WriteLine("You passed!");
        }

        else 
        {
            Console.WriteLine("Please focus more in study!");
        }



    }
}