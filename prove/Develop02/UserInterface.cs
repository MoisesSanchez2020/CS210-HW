public class UserInterface
{
    private Journal journal;

    public UserInterface(Journal journal)
    {
        this.journal = journal;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
    }

    public void WriteNewEntry()
    {
        // TODO: Choose a random prompt from a list and prompt user for response
        JournalEntry entry = new JournalEntry();
        journal.AddEntry(entry);
    }

    public void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter filename to save journal to:");
        string filename = Console.ReadLine();
        journal.SaveEntries(filename);
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter filename to load journal from:");
        string filename = Console.ReadLine();
        journal.LoadEntries(filename);
    }
}
