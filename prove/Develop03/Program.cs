using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private readonly string _reference;
    private readonly List<ScriptureWord> _words;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public string GetReference()
    {
        return _reference;
    }

    public bool IsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void HideRandomWord()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(_words.Count);
        _words[randomIndex].Hide();
    }

    public override string ToString()
    {
        return $"{_reference}: {string.Join(" ", _words)}";
    }
}

class ScriptureReference
{
    private readonly int _startChapter;
    private readonly int _startVerse;
    private readonly int _endChapter;
    private readonly int _endVerse;

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(':');
        string[] start = parts[1].Split('-');

        _startChapter = int.Parse(parts[0]);
        _startVerse = int.Parse(start[0]);

        if (start.Length > 1)
        {
            _endChapter = _startChapter;
            _endVerse = int.Parse(start[1]);
        }
        else
        {
            _endChapter = _startChapter;
            _endVerse = _startVerse;
        }
    }

    public int GetStartChapter()
    {
        return _startChapter;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public int GetEndChapter()
    {
        return _endChapter;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public override string ToString()
    {
        if (_startChapter == _endChapter)
        {
            if (_startVerse == _endVerse)
            {
                return $"{_startChapter}:{_startVerse}";
            }
            else
            {
                return $"{_startChapter}:{_startVerse}-{_endVerse}";
            }
        }
        else
        {
            return $"{_startChapter}:{_startVerse}-{_endChapter}:{_endVerse}";
        }
    }
}

class ScriptureWord
{
    private readonly string _word;
    private bool _hidden;

    public ScriptureWord(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public override string ToString()
    {
        return _hidden ? "___" : _word;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.WriteLine(scripture);

        while (!scripture.IsHidden())
        {
            Console.WriteLine("Press enter to continue or type quit to end.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWord();

            Console.Clear();
            Console.WriteLine(scripture);
        }
    }
}
