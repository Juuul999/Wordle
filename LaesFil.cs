using System;
using System.Collections.Generic;
using System.IO;

namespace Wordle
{
    public class LaesFil
    {
        private string filePath;
        private List<string> words;

        public LaesFil(string filePath)
        {
            this.filePath = filePath;
            this.words = new List<string>();
            LoadWords();
        }

        private void LoadWords()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var word = line.Trim().ToUpper();  // Trim spaces and convert to uppercase
                        if (word.Length == 5)  // Ensure the word is 5 letters long
                        {
                            words.Add(word);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                    // Optionally log or show a message to the user about the issue
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }

        public string GetRandomWord()
        {
            if (words.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(words.Count);
                return words[index];  // Return a random word
            }
            else
            {
                // Return a default word if no words were loaded
                return "HALLO";
            }
        }
    }
}