using MathNet.Numerics;
using System.Linq;
using View;

namespace Model
{
    public static class Dale_Chall
    {
        public static string Readibility(string text)
        {
            double readibility = 0.1579 * DifficultWordsPercentage(text) + 0.0496 * WordsSentencesRatio(text);
            if (double.IsNaN(readibility))
            {
                return "Nie wyznaczono";
            }
            return readibility.Round(3).ToString();
        }

        static double DifficultWordsPercentage(string text)
        {
            string[] words = StatisticsCalculator.ExtractWords(text);

            int difficultWordsAmount = words.Count(word => word.Length > 7);

            double percentage = (double)difficultWordsAmount / words.Length * 100;

            return percentage;
        }

        static double WordsSentencesRatio(string text)
        {
            string[] words = StatisticsCalculator.ExtractWords(text);
            int wordsCount = words.Length;

            string[] sentences = text.Split(new char[] { '.', '!', '?' });
            int sentencesCount = sentences.Length;

            return wordsCount/sentencesCount;
        }

    }
}
