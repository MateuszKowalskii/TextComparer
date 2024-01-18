using ICSharpCode.AvalonEdit.Highlighting;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Controls;
using View;

namespace ViewModel
{
    public class OperationsViewer //: BindableBase
    {
        public DelegateCommand IncreaseFontCommand { get; }
        public DelegateCommand DecreaseFontCommand { get; }
        public DelegateCommand SwapCommand { get; }
        public DelegateCommand ShowLineNumbersCommand { get; }
        public DelegateCommand<string> HighlightCommand { get; }
        public DelegateCommand<string> ClearCommand { get; }

        private MainWindow mainWindow;

        public OperationsViewer(MainWindow mainWindow)
        {
            IncreaseFontCommand = new DelegateCommand(IncreaseTbFontSize);
            DecreaseFontCommand = new DelegateCommand(DecreaseTbFontSize);
            SwapCommand = new DelegateCommand(SwapTexts);
            ShowLineNumbersCommand = new DelegateCommand(ChangeLineNumbersVisibility);
            HighlightCommand = new DelegateCommand<string>(HighlightKeyWords);
            ClearCommand = new DelegateCommand<string>(ClearTextBox);

            this.mainWindow = mainWindow;
        }
        private void IncreaseTbFontSize()
        {
            mainWindow.LeftTextBox.FontSize++;
            mainWindow.RightTextBox.FontSize++;
        }

        private void DecreaseTbFontSize()
        {
            mainWindow.LeftTextBox.FontSize--;
            mainWindow.RightTextBox.FontSize--;
        }

        private void SwapTexts()
        {
            (mainWindow.rightFilePath.Text, mainWindow.leftFilePath.Text) = (mainWindow.leftFilePath.Text, mainWindow.rightFilePath.Text);
            (mainWindow.rightTextBox.Text, mainWindow.leftTextBox.Text) = (mainWindow.leftTextBox.Text, mainWindow.rightTextBox.Text);
        }

        private void ChangeLineNumbersVisibility()
        {
            mainWindow.LeftTextBox.ShowLineNumbers = !mainWindow.LeftTextBox.ShowLineNumbers;
            mainWindow.RightTextBox.ShowLineNumbers = !mainWindow.RightTextBox.ShowLineNumbers;
        }

        private void HighlightKeyWords(string language)
        {
            int.TryParse(language, out int chosenLanguage);
            MenuItem[] menuItems = { mainWindow.TEXT, mainWindow.CSS, mainWindow.CS, mainWindow.HTML, mainWindow.JAVA,
                mainWindow.JS, mainWindow.PY, mainWindow.XML};

            foreach (MenuItem item in menuItems) {
                if (item.CommandParameter.ToString() != language) item.IsChecked = false;
            }

            switch (chosenLanguage)
            {
                case 0:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension("");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension("");
                    break;
                case 1:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".css");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".css");
                    break;
                case 2:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");
                    break;
                case 3:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
                    break;
                case 4:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".java");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".java");
                    break;
                case 5:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".js");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".js");
                    break;
                case 6:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".py");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".py");
                    break;
                case 7:
                    mainWindow.LeftTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
                    mainWindow.RightTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
                    break;
            }
        }

        private void ClearTextBox(string side)
        {
            if (side == "L")
            {
                mainWindow.leftFilePath.Text = string.Empty;
                mainWindow.leftTextBox.SelectAll();
                mainWindow.leftTextBox.SelectedText = string.Empty;
            }
            else
            {
                mainWindow.rightFilePath.Text = string.Empty;
                mainWindow.rightTextBox.SelectAll();
                mainWindow.rightTextBox.SelectedText = string.Empty;
            }

        }
    }
}
