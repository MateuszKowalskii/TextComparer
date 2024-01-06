using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ViewModel
{
    public static class StatisticsCalculator
    {
        public static string WordFrequency(string text, int numberOfResults)
        {
            string[] dictionary = Regex.Split(text, @"\P{L}+")
                              .Where(slowo => !string.IsNullOrWhiteSpace(slowo))
                              .ToArray();

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
            string[] words = Regex.Split(text, @"\P{L}+")
                  .Where(slowo => !string.IsNullOrWhiteSpace(slowo))
                  .ToArray();
            return words.Length;
        }

        public static int CountUniqueWords(string text)
        {
            string[] dictionary = Regex.Split(text, @"\P{L}+")
                              .Where(slowo => !string.IsNullOrWhiteSpace(slowo))
                              .ToArray();

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
    }
}
