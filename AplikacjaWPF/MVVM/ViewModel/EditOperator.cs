using ICSharpCode.AvalonEdit;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using View;

namespace ViewModel
{
    public class EditOperator : BindableBase
    {
        public DelegateCommand CopyCommand { get; }
        public DelegateCommand PasteCommand { get; }
        public DelegateCommand CutCommand { get; }
        private MainWindow mainWindow;

        public EditOperator(MainWindow mainWindow)
        {
            CopyCommand = new DelegateCommand(Copy);
            PasteCommand = new DelegateCommand(Paste);
            CutCommand = new DelegateCommand(Cut);
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
    }
}
