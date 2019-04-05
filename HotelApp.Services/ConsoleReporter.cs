using Hotel.Services.Abstract;
using System;

namespace HotelApp.Services
{
    public class ConsoleReporter : IReporter
    {
        public void SendReport(string text)
        {
            Console.WriteLine(text);
        }

        public void SendReport(int value1, int value2)
        {
            System.Console.SetCursorPosition(value1, value2);
        }
         public string SendReport()
        {
            string value = Console.ReadLine();
            return value;
        }
    }
}
