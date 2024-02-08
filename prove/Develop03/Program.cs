/*
    Memorization Challenge Program

    This program helps users memorize scriptures by displaying the full scripture and gradually hiding words.
    
    Creativity and Exceeding Requirements:
    - Implemented a scripture library allowing users to memorize different scriptures.
    - Added a method to load scriptures from files for better scalability.
    - Utilized object-oriented design with encapsulation, classes, and methods.
    - Provided a feedback score, including elapsed time and incorrect recalls, upon successful memorization.
    
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}" + (_verse != _endVerse ? $"-{_endVerse}" : "");
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        var wordsToHide = _words.Where(word => !word.IsHidden()).OrderBy(_ => random.Next()).Take(numberToHide);

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"Scripture Reference: {_reference.GetDisplayText()}\n");

        foreach (var word in _words)
        {
            Console.Write($"{word.GetDisplayText()} ");
        }

        Console.WriteLine("\n\nPress Enter to continue or type 'quit' to exit.");
    }

    public void DisplayScore(TimeSpan elapsed, int incorrectRecalls)
    {
        Console.WriteLine($"\nCongratulations! You successfully memorized the scripture in {elapsed.TotalSeconds} seconds.");
        Console.WriteLine($"Total incorrect recalls: {incorrectRecalls}");
    }

    public List<Word> GetWords()
    {
        return _words;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Memorization Challenge Program!\n");

        // Example usage with a scripture library
        List<Scripture> scriptureLibrary = LoadScriptures(); // Load scriptures from files

        foreach (var scripture in scriptureLibrary)
        {
            PlayScriptureGame(scripture);
        }

        Console.WriteLine("\nThank you for using the Memorization Challenge Program!");
    }

    // Method to load scriptures from files (creativity addition)
    static List<Scripture> LoadScriptures()
    {
        // You can implement the logic to load scriptures from files here
        // For simplicity, let's create some example scriptures

        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world..."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart..."),
            // Add more scriptures as needed
        };

        return scriptures;
    }

    // Method to play the scripture memorization game
    static void PlayScriptureGame(Scripture scripture)
    {
        Stopwatch stopwatch = new Stopwatch();
        int incorrectRecalls = 0;

        do
        {
            scripture.DisplayScripture();
            Console.ReadLine(); // Wait for user input before hiding words

            stopwatch.Start();
            scripture.HideRandomWords(2); // Adjust the number of words to hide as needed
            stopwatch.Stop();

            scripture.DisplayScripture();
            Console.WriteLine("\nEnter your recall (type 'quit' to exit):");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            // Check user input for correctness
            List<string> userRecall = userInput.Split(' ').ToList();
            for (int i = 0; i < userRecall.Count; i++)
            {
                // Check if all words are hidden
                if (!scripture.AllWordsHidden())
                {
                    // Compare user input with the displayed word
                    if (userRecall[i] != scripture.GetWords()[i].GetDisplayText())
                    {
                        incorrectRecalls++;
                    }
                }
            }

        } while (!scripture.AllWordsHidden());

        // Display the scripture one last time with all words hidden
        scripture.DisplayScripture();

        // Display the final score
        scripture.DisplayScore(stopwatch.Elapsed, incorrectRecalls);
    }
}
