
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);

            visibleWords[randomIndex].Hide();

            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(word => word.IsHidden());
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public string GetDisplayText()
    {
        string displayedWords = "";

        foreach (Word word in _words)
        {
            displayedWords += word.GetDisplayText() + " ";
        }

        return _reference.GetDisplayText() + "\n" + displayedWords.Trim();
    }
}
