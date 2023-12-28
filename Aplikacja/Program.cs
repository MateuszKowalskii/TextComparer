namespace Aplikacja
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new mainForm());
            //TODO https://www.youtube.com/watch?v=BtOEztT1Qzk&t=10s
        }
    }
}