using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a math assignment with the student name "Roberto Rodriguez", topic "Fractions",
            // assignment number "7.3", and due date "8-19"
            MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");

            // Print the summary of the math assignment, which includes the student name and topic
            Console.WriteLine(mathAssignment.GetSummary());

            // Print the list of homework for the math assignment, which includes the assignment number and due date
            Console.WriteLine(mathAssignment.GetHomeworkList());

            // Create a writing assignment with the student name "Mary Waters", topic "European History",
            // and title "The Causes of World War II"
            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

            // Print the summary of the writing assignment, which includes the student name and topic
            Console.WriteLine(writingAssignment.GetSummary());

            // Print the writing information of the writing assignment, which includes the title and the student name
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }
}
