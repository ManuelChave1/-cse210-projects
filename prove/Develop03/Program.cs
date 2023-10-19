using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Create a Scripture instance with a reference and 
        Scripture scripture = new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        // Create a Memorizer and associate it with the scripture
        Memorizer memorizer = new Memorizer(scripture);

        while (memorizer.HasWordsToHide())
        {
            Console.Clear();
            Console.WriteLine(memorizer.GetHiddenScripture());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                break;

            memorizer.HideRandomWords();
        }

        Console.WriteLine("\nAll words in the scripture are hidden. Memorization complete!");
    }
}

class Scripture
{
    public string Reference { get; private set; }
    public string Text { get; private set; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }
}

class Memorizer
{
    private Scripture scripture;
    private List<string> hiddenWords;

    public Memorizer(Scripture scripture)
    {
        this.scripture = scripture;
        hiddenWords = new List<string>();
    }

    public bool HasWordsToHide()
    {
        return hiddenWords.Count < scripture.Text.Split(' ').Length;
    }

    public void HideRandomWords()
    {
        string[] words = scripture.Text.Split(' ');
        List<string> visibleWords = words.Except(hiddenWords).ToList();
        if (visibleWords.Count > 0)
        {
            int index = new Random().Next(visibleWords.Count);
            hiddenWords.Add(visibleWords[index]);
        }
    }

    public string GetHiddenScripture()
    {
        string[] words = scripture.Text.Split(' ');
        StringBuilder hiddenText = new StringBuilder();

        foreach (string word in words)
        {
            if (hiddenWords.Contains(word))
                hiddenText.Append(new string('-', word.Length) + " ");
            else
                hiddenText.Append(word + " ");
        }

        return $"{scripture.Reference}\n{hiddenText.ToString().Trim()}";
    }
}
