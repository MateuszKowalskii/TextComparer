using Prism.Commands;
using View;

namespace ViewModel
{
    public class MainViewModel
    {
        //OperationsViewer
        public DelegateCommand IncreaseFontCommand => OperationsViewer.IncreaseFontCommand;
        public DelegateCommand DecreaseFontCommand => OperationsViewer.DecreaseFontCommand;
        public DelegateCommand SwapCommand => OperationsViewer.SwapCommand;
        public DelegateCommand ShowLineNumbersCommand => OperationsViewer.ShowLineNumbersCommand;
        public DelegateCommand<string> HighlightCommand => OperationsViewer.HighlightCommand;
        public DelegateCommand<string> ClearCommand => OperationsViewer.ClearCommand;
        public OperationsViewer OperationsViewer { get; }

        //WindowStateEditor
        public DelegateCommand MinimizeCommand => WindowStateEditor.MinimizeCommand;
        public DelegateCommand MaximizeCommand => WindowStateEditor.MaximizeCommand;
        public DelegateCommand CloseCommand => WindowStateEditor.CloseCommand;
        public DelegateCommand ShowAdvancedResultsCommand => WindowStateEditor.AdvancedResultsCommand;
        public WindowStateEditor WindowStateEditor { get; }

        //ComparationExecutor
        public DelegateCommand<string> ChangeAlgorythmCommand => ComparationExecutor.ChangeAlgorythmCommand;
        public DelegateCommand<string> ChangeModeCommand => ComparationExecutor.ChangeModeCommand;
        public DelegateCommand ExecuteCommand => ComparationExecutor.ExecuteCommand;
        public DelegateCommand IgnoreSizesCommand => ComparationExecutor.IgnoreSizesCommand;
        public DelegateCommand IgnoreWhitespacesCommand => ComparationExecutor.IgnoreWhitespacesCommand;
        public DelegateCommand IgnorePunctationCommand => ComparationExecutor.IgnorePunctationCommand;
        public DelegateCommand AdvancedResultsCommand => ComparationExecutor.AdvancedResultsCommand;
        public ComparationExecutor ComparationExecutor { get; }

        //DocsReader
        public DelegateCommand<string> OpenFileCommand => DocsReader.OpenFileCommand;
        public DocsReader DocsReader { get; }

        //EditOptions
        public DelegateCommand CopyCommand => EditOptions.CopyCommand;
        public DelegateCommand PasteCommand => EditOptions.PasteCommand;
        public DelegateCommand CutCommand => EditOptions.CutCommand;
        public EditOperator EditOptions { get; }


        private MainWindow mainWindow;

        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            OperationsViewer = new OperationsViewer(this.mainWindow);
            WindowStateEditor = new WindowStateEditor(this.mainWindow);
            ComparationExecutor = new ComparationExecutor(this.mainWindow);
            DocsReader = new DocsReader(this.mainWindow);
            EditOptions = new EditOperator(this.mainWindow);
        }
    }
}
