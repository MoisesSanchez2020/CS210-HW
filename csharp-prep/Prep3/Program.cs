using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int magicNumber = rand.Next(1, 101);
        
        Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");
        
        int guess = 0;
        while (guess != magicNumber) {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();
            
            if (!int.TryParse(input, out guess)) {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }
            
            if (guess < magicNumber) {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber) {
                Console.WriteLine("Lower");
            }
            else {
                Console.WriteLine("You guessed it!");
            }
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
} 