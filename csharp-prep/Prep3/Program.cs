using System;

class Program
{
    static void Main(string[] args)
    {
        string playMore = "yes";
        int guess = 0;

        while (playMore == "yes")
        {
            guess = 0;

            Console.Write("What is the secret number? ");
            int secretNumber = int.Parse(Console.ReadLine());

            while (guess != secretNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (secretNumber < guess)
                {
                    Console.WriteLine("try Lower");
                }

                else if (secretNumber > guess)
                {
                    Console.WriteLine("try Higher");
                }

                else 
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.Write("Do you want to play again? ");
            playMore = Console.ReadLine();

        }
    }
} 