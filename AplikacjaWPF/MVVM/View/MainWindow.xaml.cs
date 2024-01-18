using AplikacjaWPF.MVVM.View.UserControls;
using ICSharpCode.AvalonEdit;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;


namespace View
{
    public partial class MainWindow : Window
    {
        //public TextBox LeftPathTextBox { get; set; }
        public TextEditor LeftTextBox { get; set; }

        //public TextBox RightPathTextBox { get; set; }
        public TextEditor RightTextBox { get; set; }

        //public TextBlock AlgorythmBlock { get; set; }
        //public TextBlock ResultsBlock { get; set; }
        //private TextBox WordsAmount { get; set; }

        public WindowState State { get; set; }
        //public AdvancedResultsPanel ResultsPanel { get; set; }
        private MainViewModel MainViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            State = WindowState;
            MainViewModel = new MainViewModel(this);
            DataContext = MainViewModel;
            //WordsAmount = wordsAmount;

            //LeftPathTextBox = leftFilePath;
            LeftTextBox = leftTextBox;
            leftTextBox.TextChanged += MainViewModel.ComparationExecutor.highlighter.TextChanged;

            //RightPathTextBox = rightFilePath;
            RightTextBox = rightTextBox;
            rightTextBox.TextChanged += MainViewModel.ComparationExecutor.highlighter.TextChanged;

            //AlgorythmBlock = blAlgorythm;
            //ResultsBlock = blResult;
            //ResultsPanel = resultsPanel;
        }
        private void TextChanged([AllowNull] object sender, EventArgs e)
        {
            MainViewModel.ComparationExecutor.highlighter.ClearColors();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
