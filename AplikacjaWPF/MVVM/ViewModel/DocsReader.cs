using ICSharpCode.AvalonEdit;
using Prism.Commands;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View;
using Xceed.Words.NET;

namespace ViewModel
{
    public class DocsReader
    {
        public DelegateCommand<string> OpenFileCommand { get; }
        private MainWindow mainWindow;

        public DocsReader(MainWindow mainWindow)
        {
            OpenFileCommand = new DelegateCommand<string>(async (side) => await OpenNewFileAsync(side));
            this.mainWindow = mainWindow;
        }
        private async Task OpenNewFileAsync(string side)
        {
            await Task.Run(() => OpenNewFile(side));
        }
        private void OpenNewFile(string side)
        {
            if (side == "L") NewFile(mainWindow.leftFilePath, mainWindow.leftTextBox);
            else if (side == "R") NewFile(mainWindow.rightFilePath, mainWindow.rightTextBox);
        }
        private void ReadDocxFile(string filePath, System.Windows.Controls.TextBox tbPath, TextEditor tbText)
        {
            try
            {
                using (DocX doc = DocX.Load(filePath))
                {
                    if (doc != null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {            
                            tbText.Text = string.Join(Environment.NewLine, doc.Paragraphs.Select(p => p.Text));
                            tbPath.Text = filePath;
                        });
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Plik jest już otwarty w innym edytorze. Zamknij go jeśli chcesz otworzyć ten plik.",
                    "Błąd otwarcia pliku", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało się otworzyć pliku",
                    "Błąd otwarcia pliku", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void NewFile(System.Windows.Controls.TextBox tbPath, TextEditor tbText)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new();
            fileDialog.Filter = "Wszystkie|*.txt;*.docx;*.css;*.html;*.js;*.py;*.cs;*.java|Pliki tekstowe txt|*.txt|Pliki docx|*.docx" +
                "|Pliki CSS|*.css|Pliki HTML|*.html|Pliki JS|*.js|Pliki Python|*.py|Pliki C#|*.cs|Pliki Java|*.java";

            fileDialog.Title = "Proszę, wybierz plik tekstowy, który chcesz porównać...";
            bool? success = fileDialog.ShowDialog();

            if (success == true)
            {
                Application.Current.Dispatcher.Invoke(() => mainWindow.progressBar.Visibility = Visibility.Visible);

                var fileName = fileDialog.FileName;
                FileInfo fileInfo = new(fileName);
                string extension = fileInfo.Extension;

                long maxSizeInBytes = 1L * 1024 * 1024 * 1024;
                if (fileInfo.Length > maxSizeInBytes)
                {
                    MessageBox.Show("Plik jest zbyt duży (przekracza 1GB) i nie może być otwarty.",
                        "Błąd otwarcia pliku", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (extension == ".docx")
                {
                    ReadDocxFile(fileName, tbPath, tbText);
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        tbPath.Text = fileName;
                        tbText.Text = File.ReadAllText(fileName, Encoding.UTF8);
                    });
                }
                Application.Current.Dispatcher.Invoke(() => mainWindow.progressBar.Visibility = Visibility.Collapsed);
            }
        }
    }
}