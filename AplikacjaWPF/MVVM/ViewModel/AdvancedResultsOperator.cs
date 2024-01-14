using Model;
using System;
using View;

namespace ViewModel
{
    public class AdvancedResultsOperator
    {
        private MainWindow mainWindow;
        public AdvancedResultsOperator(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void PresentAdvancedResults(string firstString, string secondString, double result)
        {
            if (result >= 0.8) mainWindow.resultsPanel.blSimilarity.Text = "Porównywane teksty MOŻNA uznać za takie same";
            else mainWindow.resultsPanel.blSimilarity.Text = "Porównywanych tekstów NIE MOŻNA uznać za takie same";

            mainWindow.resultsPanel.blTextsStats.Text = "Ilość znaków:\nTekst lewy: " + StatisticsCalculator.CountCharacters(firstString) 
                + "\nTekst prawy: " + StatisticsCalculator.CountCharacters(secondString) + "\n\n";

            mainWindow.resultsPanel.blTextsStats.Text += "Ilość słów:\nTekst lewy: " + StatisticsCalculator.CountWords(firstString)
                + "\nTekst prawy: " + StatisticsCalculator.CountWords(secondString) + "\n\n";

            mainWindow.resultsPanel.blTextsStats.Text += "Ilość unikalnych słów:\nTekst lewy: " + StatisticsCalculator.CountUniqueWords(firstString)
                + "\nTekst prawy: " + StatisticsCalculator.CountUniqueWords(secondString) + "\n\n";

            mainWindow.resultsPanel.blTextsStats.Text += "Stopień czytelności Dale’a – Challa:\nTekst lewy: " + Dale_Chall.Readibility(firstString)
                + "\nTekst prawy: " + Dale_Chall.Readibility(secondString) + "\n\n";
            
            mainWindow.resultsPanel.blTextsStats.Text += "Entropia:\nTekst lewy: " + StatisticsCalculator.CalculateEntropy(firstString)
                + "\nTekst prawy: " + StatisticsCalculator.CalculateEntropy(secondString) + "\n\n";

            int amount;
            try
            {
                amount = int.Parse(mainWindow.wordsAmount.Text);
            }
            catch (Exception)
            {
                amount = 10;
            }

            mainWindow.resultsPanel.blLeftWordFrequencyStatistics.Text = "Najczęstsze wyrazy lewego tekstu:\n\n" + StatisticsCalculator.WordFrequency(firstString, amount);
            mainWindow.resultsPanel.blRightWordFrequencyStatistics.Text = "Najczęstsze wyrazy prawego tekstu:\n\n" + StatisticsCalculator.WordFrequency(secondString, amount);

        }
    }
}
