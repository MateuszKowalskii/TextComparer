using MathNet.Numerics;
using Model;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using View;

namespace ViewModel
{
    public class ComparationExecutor //: BindableBase
    {
        public DelegateCommand<string> ChangeAlgorythmCommand { get; }
        public DelegateCommand<string> ChangeModeCommand { get; }
        public DelegateCommand ExecuteCommand { get; }
        public DelegateCommand IgnoreSizesCommand { get; }
        public DelegateCommand IgnoreWhitespacesCommand { get; }
        public DelegateCommand IgnorePunctationCommand { get; }
        public DelegateCommand AdvancedResultsCommand { get; }
        public DelegateCommand HighlightLinesCommand { get; }
        public DelegateCommand ClearHighlightLinesCommand { get; }

        private enum Algorythm { Jaro, JaroWinkler, Jaccard, Levenshtein };
        private enum Mode { Percentage, Absolute};

        private static int currentAlgorythm = (int)Algorythm.Jaro;
        private static int currentMode = (int)Mode.Percentage;

        private AdvancedResultsOperator advancedResultsOperator;
        public Highlighter highlighter;
        private MainWindow mainWindow;

        private bool differSignSizes = false;
        private bool ignoreWhitespaces = true;
        private bool ignorePunctation = false;
        private bool advancedResults = true;

        public ComparationExecutor(MainWindow mainWindow)
        {
            ChangeAlgorythmCommand = new DelegateCommand<string>(ChangeCurrentAlgorythm);
            ChangeModeCommand = new DelegateCommand<string>(ChangeCurrentMode);

            ExecuteCommand = new DelegateCommand(async () => await ExecuteAlgorythmAsync());
            IgnoreSizesCommand = new DelegateCommand(() => { differSignSizes = !differSignSizes; });
            IgnoreWhitespacesCommand = new DelegateCommand(() => {  ignoreWhitespaces = !ignoreWhitespaces; });
            IgnorePunctationCommand = new DelegateCommand(() => {  ignorePunctation = !ignorePunctation; });

            HighlightLinesCommand = new DelegateCommand(async () => { await HighlightLinesAsync(); });
            ClearHighlightLinesCommand = new DelegateCommand(() => highlighter?.ClearColors());

            AdvancedResultsCommand = new DelegateCommand(ChangeAdvancedResultsMode);

            advancedResultsOperator = new AdvancedResultsOperator(mainWindow);
            highlighter = new Highlighter(mainWindow);
            this.mainWindow = mainWindow;
        }

        public void ChangeCurrentAlgorythm(string chosenAlgorythm)
        {
            MenuItem[] menuItems = { mainWindow.Jaro, mainWindow.JaroWinkler, mainWindow.Jaccard, mainWindow.Levenshtein };
            int.TryParse(chosenAlgorythm, out currentAlgorythm);

            foreach (MenuItem item in menuItems)
            {
                if (item.CommandParameter.ToString() != chosenAlgorythm) item.IsChecked = false;
                else {
                    mainWindow.blAlgorythm.Text = "Wybrany algorytm:\n" + item.Name;
                    if (item != mainWindow.Jaro) mainWindow.blAlgorythm.Text += "a";
                }
            }
        }

        public void ChangeCurrentMode(string chosenMode)
        {
            MenuItem[] menuItems = { mainWindow.Percentage, mainWindow.Absolute };
            int.TryParse(chosenMode, out currentMode);

            foreach (MenuItem item in menuItems)
            {
                if (item.CommandParameter.ToString() != chosenMode) item.IsChecked = false;
            }
        }

        public void ChangeAdvancedResultsMode()
        {
            advancedResults = !advancedResults;
            if(advancedResults == true)
            {
                mainWindow.FrequentWords.Visibility = Visibility.Visible;
                mainWindow.btnAdvancedResults.Visibility = Visibility.Visible;
                mainWindow.btnAdvancedResults.IsEnabled = true;
            }
            else
            {
                mainWindow.FrequentWords.Visibility = Visibility.Collapsed;
                mainWindow.resultsPanel.Visibility = Visibility.Hidden;
                mainWindow.btnAdvancedResults.Visibility = Visibility.Hidden;
                mainWindow.btnAdvancedResults.IsEnabled = false;
            }
        }

        private async System.Threading.Tasks.Task ExecuteAlgorythmAsync()
        {
            await System.Threading.Tasks.Task.Run(() => ExecuteAlgorythm());
        }

        private async System.Threading.Tasks.Task HighlightLinesAsync()
        {
            await System.Threading.Tasks.Task.Run(() => highlighter.CompareLines());
        }

        private void ExecuteAlgorythm()
        {
            Application.Current.Dispatcher.Invoke(() => mainWindow.progressBar.Visibility = Visibility.Visible);
            double result = 0;
            Highlighter highlighter = new Highlighter(mainWindow);

            Application.Current.Dispatcher.Invoke(() =>
            {
                //Preparing texts for comparasion
                string leftString = TextPreparator.PrepareTexts(mainWindow.LeftTextBox.Text,
                    differSignSizes, ignoreWhitespaces, ignorePunctation);
                string rightString = TextPreparator.PrepareTexts(mainWindow.RightTextBox.Text,
                    differSignSizes, ignoreWhitespaces, ignorePunctation);

                //Calculate proper distance
                if (string.IsNullOrEmpty(leftString) && string.IsNullOrEmpty(rightString))
                    result = 1;
                else if (string.IsNullOrEmpty(leftString) || string.IsNullOrEmpty(rightString))
                    result = 0;
                else if (currentAlgorythm == (int)Algorythm.Jaro)
                    result = JaroWinkler.JaroDistance(leftString, rightString);
                else if (currentAlgorythm == (int)Algorythm.JaroWinkler)
                    result = JaroWinkler.JaroWinklerDistance(leftString, rightString);
                else if (currentAlgorythm == (int)Algorythm.Jaccard)
                    result = Jaccard.JaccardDistance(leftString, rightString);
                else if (currentAlgorythm == (int)Algorythm.Levenshtein)
                    result = Levenshtein.LevenshteinDistance(leftString, rightString);

                result = result.Round(3);

                //Present advanced results
                if (advancedResults == true)
                {
                    advancedResultsOperator.PresentAdvancedResults(mainWindow.LeftTextBox.Text, mainWindow.RightTextBox.Text, result);
                }

                //Present basic results
                if (currentMode == (int)Mode.Percentage)
                    mainWindow.blResult.Text = "Podobieństwo\nprocentowe:\n" + (result * 100).Round(3).ToString() + "%";
                else if (currentMode == (int)Mode.Absolute)
                    mainWindow.blResult.Text = "Podobieństwo\nbezwzględne:\n" + result.Round(3).ToString();
            });

            Application.Current.Dispatcher.Invoke(() => mainWindow.progressBar.Visibility = Visibility.Hidden);
        }
    }
}
