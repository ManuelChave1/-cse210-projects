using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var scripture = new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        var memorizer = new Memorizer(scripture);

        while (memorizer.HasWordsToHide())
        {
            Console.Clear();
            Console.WriteLine(memorizer.GetHiddenScripture());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            var input = Console.ReadLine();

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
    public List<Word> Words { get; private set; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        Words = text.Split(' ').Select(_ => new Word(_)).ToList();
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

class Memorizer
{
    private Scripture _scripture;

    public Memorizer(Scripture scripture)
    {
        _scripture = scripture;
    }

    public bool HasWordsToHide()
    {
        return _scripture.Words.Any(_ => !_.IsHidden);
    }

    public void HideRandomWords()
    {
        var hiddenWords = _scripture.Words.Where(_ => !_.IsHidden).ToList();
        if (hiddenWords.Count > 0)
        {
            var index = new Random().Next(hiddenWords.Count);
            hiddenWords[index].IsHidden = true;
        }
    }

    public string GetHiddenScripture()
    {
        var hiddenText = new StringBuilder();

        foreach (var word in _scripture.Words)
        {
            if (word.IsHidden)
                hiddenText.Append(new string('_', word.Text.Length) + " ");
            else
                hiddenText.Append(word.Text + " ");
        }

        return $"{_scripture.Reference}\n{hiddenText.ToString().Trim()}";
    }
}
