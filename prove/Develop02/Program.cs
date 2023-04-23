using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        UserInterface ui = new UserInterface(journal);

        while (true)
        {
            ui.DisplayMenu();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ui.WriteNewEntry();
                    break;
                case "2":
                    ui.DisplayJournal();
                    break;
                case "3":
                    ui.SaveJournal();
                    break;
                case "4":
                    ui.LoadJournal();
                    break;
                case "5":
                   return;
            default:
            
                Console.WriteLine("Invalid choice. Please enter a valid choice from the menu.");
                break;
        }
    }
    }
}