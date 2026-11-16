
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // EXTRA FEATURES:
        // 1. The program includes a library of multiple Bible passages.
        // 2. A random scripture is selected for each practice session.
        // 3. A progress indicator shows the memorization percentage.
        // 4. Only visible words are selected to avoid hiding the same word twice.
        // 5. Users can exit at any time by typing "quit" or "salir".

        List<Scripture> scriptureLibrary = new List<Scripture>();

        // First Bible passage: John 3:16
        Reference reference1 = new Reference("John", 3, 16);

        Scripture scripture1 = new Scripture(
            reference1,
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life."
        );

        scriptureLibrary.Add(scripture1);

        // Second Bible passage: Proverbs 3:5-6
        Reference reference2 = new Reference("Proverbs", 3, 5, 6);

        Scripture scripture2 = new Scripture(
            reference2,
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."
        );

        scriptureLibrary.Add(scripture2);

        // Third Bible passage: Philippians 4:13
        Reference reference3 = new Reference("Philippians", 4, 13);

        Scripture scripture3 = new Scripture(
            reference3,
            "I can do all things through Christ which strengtheneth me."
        );

        scriptureLibrary.Add(scripture3);

        // Randomly select a scripture from the library.
        Random random = new Random();
        int selectedIndex = random.Next(scriptureLibrary.Count);

        Scripture selectedScripture = scriptureLibrary[selectedIndex];

        // Main memorization loop.
        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("       SCRIPTURE MEMORIZER");
            Console.WriteLine("==================================\n");

            Console.WriteLine(selectedScripture.GetDisplayText());

            // Calculate and display memorization progress.
            int hiddenWords = selectedScripture.GetHiddenWordCount();
            int totalWords = selectedScripture.GetTotalWordCount();

            double progress = (double)hiddenWords / totalWords * 100;

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"Memorization progress: {progress:F0}%");
            Console.WriteLine($"Hidden words: {hiddenWords}/{totalWords}");
            Console.WriteLine("----------------------------------");

            Console.WriteLine("\nPress ENTER to hide more words.");
            Console.WriteLine("Type 'quit' or 'salir' to exit.");

            string userInput = Console.ReadLine() ?? "";

            if (userInput.Trim().ToLower() == "quit" ||
                userInput.Trim().ToLower() == "salir")
            {
                Console.WriteLine("\nThank you for practicing!");
                return;
            }

            if (string.IsNullOrWhiteSpace(userInput))
            {
                // Hide three additional words.
                selectedScripture.HideRandomWords(3);
            }
            else
            {
                Console.WriteLine("\nPlease press ENTER or type 'quit'.");
                Console.ReadKey();
            }
        }

        // Display the final scripture with all words hidden.
        Console.Clear();

        Console.WriteLine("==================================");
        Console.WriteLine("       SCRIPTURE MEMORIZER");
        Console.WriteLine("==================================\n");

        Console.WriteLine(selectedScripture.GetDisplayText());

        Console.WriteLine("\nCongratulations!");
        Console.WriteLine("You have hidden all the words!");
        Console.WriteLine("You completed the memorization challenge!");
    }
}
