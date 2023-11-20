using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public DateTime Date { get; }
    public string Prompt { get; }
    public string Content { get; }

    public JournalEntry(DateTime date, string prompt, string content)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public List<JournalEntry> GetEntries()
    {
        return entries;
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Content}");
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && DateTime.TryParse(parts[0], out DateTime date))
                {
                    string prompt = parts[1];
                    string content = parts[2];
                    entries.Add(new JournalEntry(date, prompt, content));
                }
            }
        }
    }
}

class UserInterface
{
    private Journal journal;

    public UserInterface(Journal journal)
    {
        this.journal = journal;
    }
    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayPrompts();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        SaveJournalToFile();
                        break;
                    case 4:
                        LoadJournalFromFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public void DisplayPrompts()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);

        Console.WriteLine($"Journal Prompt: {prompts[randomIndex]}");
        Console.Write("Your response: ");
        string content = Console.ReadLine();
        journal.AddEntry(new JournalEntry(DateTime.Now, prompts[randomIndex], content));
    }

    public void DisplayJournal()
    {
        List<JournalEntry> entries = journal.GetEntries();
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Content: {entry.Content}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded from file.");
    }
}


class Program
{
 static void Main()
 {

Journal journal = new Journal();
UserInterface userInterface = new UserInterface(journal);
userInterface.DisplayMenu();
}
}