using Prism.Commands;
using System.Windows;
using View;

namespace ViewModel
{
    public class WindowStateEditor //: BindableBase
    {
        public DelegateCommand MinimizeCommand { get; }
        public DelegateCommand MaximizeCommand { get; }
        public DelegateCommand AdvancedResultsCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public MainWindow MainWindow { get; }

        public WindowStateEditor(MainWindow mainWindow)
        {
            MinimizeCommand = new DelegateCommand(MinimizeWindow);
            MaximizeCommand = new DelegateCommand(MaximizeWindow);
            AdvancedResultsCommand = new DelegateCommand(ShowResultsPanel);
            CloseCommand = new DelegateCommand(CloseApp);
            MainWindow = mainWindow;
        }

        private void MinimizeWindow()
        {
            MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow()
        {
            if (MainWindow.WindowState == WindowState.Maximized)
            {
                MainWindow.WindowState = WindowState.Normal;
            }
            else MainWindow.WindowState = WindowState.Maximized;
        }

        private void ShowResultsPanel()
        {
            if(MainWindow.resultsPanel.Visibility == Visibility.Visible) MainWindow.resultsPanel.Visibility = Visibility.Hidden;
            else MainWindow.resultsPanel.Visibility = Visibility.Visible;
        }

        private void CloseApp()
        {
            //Close();
            Application.Current.Shutdown();
        }
    }
}
