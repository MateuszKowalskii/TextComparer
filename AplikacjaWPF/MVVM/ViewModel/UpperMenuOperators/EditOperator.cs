using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Search;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ViewModel
{
    public class EditOperator : BindableBase
    {
        public DelegateCommand CopyCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand DeleteRowCommand { get; }
        public DelegateCommand PasteCommand { get; }
        public DelegateCommand CutCommand { get; }
        public DelegateCommand SelectAllCommand { get; }
        public DelegateCommand UndoCommand { get; }
        public DelegateCommand RedoCommand { get; }

        private MainWindow mainWindow;

        public EditOperator(MainWindow mainWindow)
        {
            CopyCommand = new DelegateCommand(Copy);
            DeleteCommand = new DelegateCommand(Delete);
            DeleteRowCommand = new DelegateCommand(DeleteRow);
            PasteCommand = new DelegateCommand(Paste);
            CutCommand = new DelegateCommand(Cut);
            SelectAllCommand = new DelegateCommand(SelectAll);
            UndoCommand = new DelegateCommand(Undo);
            RedoCommand = new DelegateCommand(Redo);
            this.mainWindow = mainWindow;
        }

        private void Copy()
        {
            if (!string.IsNullOrEmpty(mainWindow.leftTextBox.SelectedText) && (!string.IsNullOrEmpty(mainWindow.rightTextBox.SelectedText)))
                MessageBox.Show("Zaznacz tekst w tylko jednym oknie", "Zbyt wiele zaznaczonych tekstów", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (!string.IsNullOrEmpty(mainWindow.leftTextBox.SelectedText))
            {
                Clipboard.SetText(mainWindow.leftTextBox.SelectedText);
            }
            else if (!string.IsNullOrEmpty(mainWindow.rightTextBox.SelectedText))
            {
                Clipboard.SetText(mainWindow.rightTextBox.SelectedText);
            }
        }

        private void Delete()
        {
            if (!string.IsNullOrEmpty(mainWindow.leftTextBox.SelectedText))
            {
                mainWindow.leftTextBox.SelectedText = string.Empty;
            }
            else if (!string.IsNullOrEmpty(mainWindow.rightTextBox.SelectedText))
            {
                mainWindow.rightTextBox.SelectedText = string.Empty;
            }
        }

        private void DeleteRow()
        {
            if (mainWindow.leftTextBox.TextArea.IsKeyboardFocused)
            {
                mainWindow.leftTextBox.SelectedText = string.Empty;
                int lineIndex = mainWindow.leftTextBox.TextArea.Caret.Line;
                mainWindow.leftTextBox.Document.Replace(mainWindow.leftTextBox.Document.GetLineByNumber(lineIndex).Offset,
                    mainWindow.leftTextBox.Document.GetLineByNumber(lineIndex).TotalLength, string.Empty);
            }
            else if (mainWindow.rightTextBox.TextArea.IsKeyboardFocused)
            {
                mainWindow.rightTextBox.SelectedText = string.Empty;
                int lineIndex = mainWindow.rightTextBox.TextArea.Caret.Line;
                mainWindow.rightTextBox.Document.Replace(mainWindow.rightTextBox.Document.GetLineByNumber(lineIndex).Offset,
                    mainWindow.rightTextBox.Document.GetLineByNumber(lineIndex).TotalLength, string.Empty);
            }
        }

        private void Paste()
        {
            TextEditor textBox = mainWindow.leftTextBox;
            if (mainWindow.leftTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.leftTextBox;
            }
            else if (mainWindow.rightTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.rightTextBox;
            }

            if (textBox != null)
            {
                string clipboardText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipboardText))
                {
                    int caretOffset = textBox.CaretOffset;
                    textBox.Text = textBox.Text.Insert(caretOffset, clipboardText);
                    textBox.CaretOffset = caretOffset + clipboardText.Length;
                }
            }
        }

        private void Cut()
        {
            if (!string.IsNullOrEmpty(mainWindow.leftTextBox.SelectedText))
            {
                Clipboard.SetText(mainWindow.leftTextBox.SelectedText);
                mainWindow.leftTextBox.SelectedText = string.Empty;
            }
            else if (!string.IsNullOrEmpty(mainWindow.rightTextBox.SelectedText))
            {
                Clipboard.SetText(mainWindow.rightTextBox.SelectedText);
                mainWindow.rightTextBox.SelectedText = string.Empty;
            }
        }

        private void SelectAll()
        {
            TextEditor textBox = mainWindow.leftTextBox;
            if (mainWindow.leftTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.leftTextBox;
            }
            else if (mainWindow.rightTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.rightTextBox;
            }

            if (textBox == mainWindow.leftTextBox)
            {
                mainWindow.leftTextBox.SelectAll();
            }
            else if (textBox == mainWindow.rightTextBox)
            {
                mainWindow.rightTextBox.SelectAll();
            }
        }

        private void Undo()
        {
            TextEditor textBox = mainWindow.leftTextBox;
            if (mainWindow.leftTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.leftTextBox;
            }
            else if (mainWindow.rightTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.rightTextBox;
            }
            textBox.Undo();
        }

        private void Redo()
        {
            TextEditor textBox = mainWindow.leftTextBox;
            if (mainWindow.leftTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.leftTextBox;
            }
            else if (mainWindow.rightTextBox.TextArea.IsKeyboardFocused)
            {
                textBox = mainWindow.rightTextBox;
            }

            textBox.Redo();
        }
    }
}
