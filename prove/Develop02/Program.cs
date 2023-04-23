using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main()
        {
            var journal = new Journal();

            while (true)
            {
                Console.WriteLine("Welcome to your journal!");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.WriteEntry();
                        break;
                    case "2":
                        journal.Display();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private readonly List<Entry> entries = new();
        private readonly Random random = new();
        private readonly List<string> prompts = new()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public void WriteEntry()
        {
            var prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"{Environment.NewLine}New Entry:");
            Console.WriteLine(prompt);
            Console.Write("> ");
            string response = Console.ReadLine();

            var entry = new Entry(prompt, response, DateTime.Now.ToString());
            entries.Add(entry);

            Console.WriteLine("Entry added.");
        }

        public void Display()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries yet.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{Environment.NewLine}{entry.Prompt} ({entry.Date}):");
                    Console.WriteLine(entry.Response);
                }
            }
        }

        public void SaveToFile()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date}");
                }
            }

            Console.WriteLine("Journal saved to file.");
        }

        public void LoadFromFile()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();

            entries.Clear();

            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split('|');
                    var entry = new Entry(fields[0], fields[1], fields[2]);
                    entries.Add(entry);
                }
            }

            Console.WriteLine("Journal loaded from file.");
        }
    }

    class Entry
    {
        public string Prompt { get; }
        public string Response { get; }
        public string Date { get; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }
}
