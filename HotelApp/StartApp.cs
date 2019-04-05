using HotelApp.Services;

namespace HotelApp
{
    class StartApp
    {
        static void Main(string[] args)
        {
            ConsoleApp console = new ConsoleApp()
            {
                Reporter = new ConsoleReporter()
            };

            console.DisplayStartWindow();

            System.Console.ReadLine();
        }
    }
}
