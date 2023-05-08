using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");

            while (true)
            {
                Console.WriteLine("\nPlease select an activity: ");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");

                int selection = GetValidInput(1, 4);

                if (selection == 4)
                {
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    break;
                }



                static int GetValidInput(int min, int max)
{
    int input;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out input))
        {
            if (input >= min && input <= max)
            {
                return input;
            }
        }
        Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
    }
}


static void Delay(int milliseconds)
{
    Thread.Sleep(milliseconds);
}


                Console.WriteLine("Enter the duration of the activity (in seconds): ");
                int duration = GetValidInput(1, int.MaxValue);

                Console.WriteLine("Get ready to begin...");
                Delay(3000);

                switch (selection)
                {
                    case 1:
                        BreathingActivity(duration);
                        break;
                    case 2:
                        ReflectionActivity(duration);
                        break;
                    case 3:
                        ListingActivity(duration);
                        break;
                }

                Console.WriteLine("Great job! You have completed the activity.");
                Delay(3000);
            }
        }

        public static async Task Delay(int milliseconds)
{
    await Task.Delay(milliseconds);
}


        private static int GetValidInput(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        static void BreathingActivity(int duration)
        {
            Console.WriteLine("Breathing Activity");
            Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();

            for (int i = 1; i <= duration; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine("Breathe in...");
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                }
                Delay(1000);
            }
        }

        static void ReflectionActivity(int duration)
        {
            Console.WriteLine("Reflection Activity");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();

            string[] prompts = new string[] {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            string[] questions = new string[] {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            for (int i = 1; i <= duration; i++)
            {
                int promptIndex = i % prompts.Length;
                Console.WriteLine(prompts[promptIndex]);

                for (int j = 0; j < questions.Length; j++)
                {
                    Console.WriteLine(questions[j]);
                    Delay(2000);
                }
            }
        }


static void ListingActivity(int duration)
{
    Console.WriteLine("Listing Activity");
    Console.WriteLine("This activity will help you reflect on the good things in your life by making a list of them. " +
                      "Take a few deep breaths, relax, and let your mind wander. When you're ready, start listing " +
                      "the good things in your life. They can be big or small, anything that makes you happy or " +
                      "grateful. Don't worry about the order or the number of things on your list. Just keep " +
                      "writing until the time is up.");

    Console.WriteLine("Press any key to begin...");
    Console.ReadKey();

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(duration);

    while (DateTime.Now < endTime)
    {
        Console.WriteLine("Enter a good thing in your life:");
        string item = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(item))
        {
            Console.WriteLine("Invalid input. Please try again.");
            continue;
        }

        Console.WriteLine($"- {item}");
    }
}
    }
    }
