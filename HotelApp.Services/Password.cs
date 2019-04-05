using System;

namespace HotelApp.Services
{
    public class Password
    {
        public string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {

                        password = password.Substring(0, password.Length - 1);

                        int pos = Console.CursorLeft;

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);

                        Console.Write(" ");

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            Console.WriteLine();
            return password;
        }


        public bool ContainsLowerLetter(string _password)
        {
            foreach (char c in _password)
            {
                if ((Char.IsLetter(c)) && (Char.IsLower(c)))
                    return true;
            }
            return false;
        }

        public bool ContainsUpperLetter(string _password)
        {
            foreach (char c in _password)
            {
                if ((Char.IsLetter(c)) && (Char.IsUpper(c)))
                    return true;
            }
            return false;
        }

        public bool ContainsDigit(string _password)
        {
            foreach (char c in _password)
            {
                if (Char.IsDigit(c))
                    return true;
            }
            return false;
        }

        public bool ContainsPunctuation(string _password)
        {
            foreach (char c in _password)
            {
                if (Char.IsPunctuation(c))
                    return true;
            }
            return false;
        }

        public bool ContainsSeparator(string _password)
        {
            foreach (char c in _password)
            {
                if (Char.IsSeparator(c))
                    return true;
            }
            return false;
        }
    }
}
