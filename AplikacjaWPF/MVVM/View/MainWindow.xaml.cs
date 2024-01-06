using AplikacjaWPF.MVVM.View.UserControls;
using ICSharpCode.AvalonEdit;
using NPOI.SS.Formula.Functions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        public TextBox LeftPathTextBox { get; set; }
        public TextEditor LeftTextBox { get; set; }

        public TextBox RightPathTextBox { get; set; }
        public TextEditor RightTextBox { get; set; }

        public TextBlock AlgorythmBlock { get; set; }
        public TextBlock ResultsBlock { get; set; }
        private TextBox WordsAmount { get; set; }

        public WindowState State { get; set; }
        public AdvancedResultsPanel ResultsPanel { get; set; }
        private MainViewModel MainViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            State = WindowState;
            WordsAmount = wordsAmount;

            LeftPathTextBox = leftFilePath;
            LeftTextBox = leftTextBox;

            RightPathTextBox = rightFilePath;
            RightTextBox = rightTextBox;

            AlgorythmBlock = blAlgorythm;
            ResultsBlock = blResult;
            ResultsPanel = resultsPanel;

            MainViewModel = new MainViewModel(this);
            DataContext = MainViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
