using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace View
{
    public static class StatisticsCalculator
    {
        public static string WordFrequency(string text, int numberOfResults)
        {
            string[] dictionary = ExtractWords(text);

            Dictionary<string, int> statistics = new Dictionary<string, int>();

            foreach (string word in dictionary)
            {
                string cleanedWord = word.ToLower();
                if (statistics.ContainsKey(cleanedWord))
                {
                    statistics[cleanedWord]++;
                }
                else
                {
                    statistics[cleanedWord] = 1;
                }
            }

            string result = "";

            foreach (var a in statistics.OrderByDescending(x => x.Value).Take(numberOfResults))
            {
                result += a.Key + ": " + a.Value + "\n";
            }

            return result;
        }

        public static int CountCharacters(string text)
        {
            text = TextPreparator.RemoveWhitespace(text);
            return text.Length;
        }

        public static int CountWords(string text)
        {
            string[] words = ExtractWords(text);
            return words.Length;
        }

        public static int CountUniqueWords(string text)
        {
            string[] dictionary = ExtractWords(text);

            Dictionary<string, int> statistics = new Dictionary<string, int>();

            foreach (string word in dictionary)
            {
                string cleanedWord = word.ToLower();
                if (!statistics.ContainsKey(cleanedWord))
                {
                    statistics[cleanedWord] = 1;
                }
            }

            return statistics.Count;
        }

        public static double CalculateEntropy(string text)
        {
            if (string.IsNullOrEmpty(text))return 0.0;

            Dictionary<char, int> charFrequency = new Dictionary<char, int>();
            int totalChars = 0;

            foreach (char c in text)
            {
                if (!charFrequency.ContainsKey(c))
                    charFrequency[c] = 1;
                else
                    charFrequency[c]++;

                totalChars++;
            }

            double entropy = 0.0;

            foreach (var frequency in charFrequency.Values)
            {
                double probability = (double)frequency / totalChars;
                entropy -= probability * Math.Log2(probability);
            }

            return entropy.Round(3);
        }

        public static string[] ExtractWords(string text)
        {
            return  Regex.Split(text, @"\W+")
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .ToArray();
        }
    }
}
