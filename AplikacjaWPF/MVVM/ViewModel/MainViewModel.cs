using Prism.Commands;
using View;

namespace ViewModel
{
    public class MainViewModel
    {
        //DocsReader
        public DelegateCommand<string> OpenFileCommand => DocsReader.OpenFileCommand;
        public DocsReader DocsReader { get; }

        //EditOperator
        public DelegateCommand CopyCommand => EditOperator.CopyCommand;
        public DelegateCommand DeleteCommand => EditOperator.DeleteCommand;
        public DelegateCommand DeleteRowCommand => EditOperator.DeleteRowCommand;
        public DelegateCommand PasteCommand => EditOperator.PasteCommand;
        public DelegateCommand CutCommand => EditOperator.CutCommand;
        public DelegateCommand SelectAllCommand => EditOperator.SelectAllCommand;
        public DelegateCommand UndoCommand => EditOperator.UndoCommand;
        public DelegateCommand RedoCommand => EditOperator.RedoCommand;
        public EditOperator EditOperator { get; }

        //ViewOperator
        public DelegateCommand IncreaseFontCommand => ViewOperator.IncreaseFontCommand;
        public DelegateCommand DecreaseFontCommand => ViewOperator.DecreaseFontCommand;
        public DelegateCommand SwapCommand => ViewOperator.SwapCommand;
        public DelegateCommand ShowLineNumbersCommand => ViewOperator.ShowLineNumbersCommand;
        public DelegateCommand<string> HighlightCommand => ViewOperator.HighlightCommand;
        public DelegateCommand<string> ClearCommand => ViewOperator.ClearCommand;
        public OperationsViewer ViewOperator { get; }

        //ComparationExecutor - for Menu and Algorythms Tabs
        public DelegateCommand<string> ChangeAlgorythmCommand => ComparationExecutor.ChangeAlgorythmCommand;
        public DelegateCommand<string> ChangeModeCommand => ComparationExecutor.ChangeModeCommand;
        public DelegateCommand ExecuteCommand => ComparationExecutor.ExecuteCommand;
        public DelegateCommand IgnoreSizesCommand => ComparationExecutor.IgnoreSizesCommand;
        public DelegateCommand IgnoreWhitespacesCommand => ComparationExecutor.IgnoreWhitespacesCommand;
        public DelegateCommand IgnorePunctationCommand => ComparationExecutor.IgnorePunctationCommand;
        public DelegateCommand AdvancedResultsCommand => ComparationExecutor.AdvancedResultsCommand;
        public DelegateCommand HighlightLinesCommand => ComparationExecutor.HighlightLinesCommand;
        public DelegateCommand ClearHighlightLinesCommand => ComparationExecutor.ClearHighlightLinesCommand;
        public ComparationExecutor ComparationExecutor { get; }

        //WindowStateEditor
        public DelegateCommand MinimizeCommand => WindowStateEditor.MinimizeCommand;
        public DelegateCommand MaximizeCommand => WindowStateEditor.MaximizeCommand;
        public DelegateCommand CloseCommand => WindowStateEditor.CloseCommand;
        public DelegateCommand ShowAdvancedResultsCommand => WindowStateEditor.AdvancedResultsCommand;
        public WindowStateEditor WindowStateEditor { get; }

        private MainWindow mainWindow;

        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            ViewOperator = new OperationsViewer(this.mainWindow);
            WindowStateEditor = new WindowStateEditor(this.mainWindow);
            ComparationExecutor = new ComparationExecutor(this.mainWindow);
            DocsReader = new DocsReader(this.mainWindow);
            EditOperator = new EditOperator(this.mainWindow);
        }
    }
}
