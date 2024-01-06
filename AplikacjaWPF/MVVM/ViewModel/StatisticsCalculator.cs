using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ViewModel
{
    public static class StatisticsCalculator
    {
        public static void MostUsedWordFrequency(string text, TextBox textBox, string side, int numberOfResults)
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

            if(side=="L")textBox.Text = "Najczęstsze wyrazy lewego tekstu:\n\n";
            else if (side == "R") textBox.Text = "Najczęstsze wyrazy prawego tekstu:\n\n";
            foreach (var a in statistics.OrderByDescending(x => x.Value).Take(numberOfResults))
            {
                textBox.Text += a.Key + ": " + a.Value + "\n";
            }
        }
    }
}
