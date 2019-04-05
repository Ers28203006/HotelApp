using Hotel.Services.Abstract;
using System;

namespace HotelApp.Services
{
    public class ConsoleApp
    {
        #region поля
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public IReporter Reporter { get; set; }
        #endregion

        #region Запуск стартовой страницы
        public void DisplayStartWindow()
        {
            int left = 30;
            int top = 4;

            int choice = 0;
            bool result = false;

            while (result == false)
            {
                System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                Reporter?.SendReport(left + 15, top - 1);
                Reporter?.SendReport("СИСТЕМА БРОНИРОВАНИЯ ОТЕЛЕЙ");
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                Reporter?.SendReport(left + 10, top + 2);
                Reporter?.SendReport("1.Авторизация");
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                Reporter?.SendReport(left + 37, top + 2);
                Reporter?.SendReport("2.Региcтрация");
                System.Console.ResetColor();
                Reporter?.SendReport("\nВыберите один из двух вариантов:");

                result = int.TryParse(Reporter?.SendReport(), out choice);
                if (choice <= 0 || choice > 2)
                {
                    result = false;
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        //логика авторизации
                        break;

                    case 2:
                        Console.Clear();
                        ValidationUser validationUser = new ValidationUser()
                        {
                            Reporter = new ConsoleReporter()
                        };
                        validationUser.Validation();
                        break;

                    default:
                        Reporter?.SendReport("Введено не верное значение, для нового ввода нажмите любую кнопку...");
                        Reporter?.SendReport();
                        Console.Clear();
                        break;
                }

            }
        }
        #endregion

        #region Окно регистрации
        public void DisplayRegistrationWindow()
        {
            int heightWindow = 24;
            int widthWindows = 45;
            int left = 30;
            int top = 4;

            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            Reporter?.SendReport(left + 15, top - 1);
            Reporter?.SendReport("РЕГИСТРАЦИЯ");

            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i <= heightWindow; i++)
            {
                Reporter?.SendReport(left, top + i);
                Reporter?.SendReport("|");

                Reporter?.SendReport(left + widthWindows - 1, top + i);
                Reporter?.SendReport("|");

            }

            for (int j = 0; j < heightWindow; j += 2)
            {
                for (int i = 0; i < widthWindows; i++)
                {
                    Reporter?.SendReport(left + i, top + j);
                    System.Console.Write("-");
                    Reporter?.SendReport(left + i, top + heightWindow);
                    System.Console.Write("-");
                }
            }
            System.Console.ResetColor();

            System.Console.ForegroundColor = ConsoleColor.DarkCyan;
            Reporter?.SendReport(left + 3, 5);
            Reporter?.SendReport("Логин:");
            Reporter?.SendReport(left + 3, 9);
            Reporter?.SendReport("Имя:");
            Reporter?.SendReport(left + 3, 13);
            Reporter?.SendReport("Email:");
            Reporter?.SendReport(left + 3, 17);
            Reporter?.SendReport("Пароль:");
            Reporter?.SendReport(left + 3, 21);
            Reporter?.SendReport("Повтор пароля:");
            Reporter?.SendReport(left + 3, 25);
            Reporter?.SendReport("Телефон:");
            System.Console.ResetColor();

            Reporter?.SendReport(left + 1, 7);
            Login = Reporter?.SendReport();
            Reporter?.SendReport(left + 1, 11);
            Name = Reporter?.SendReport();
            Reporter?.SendReport(left + 1, 15);
            Email = Reporter?.SendReport();
            Reporter?.SendReport(left + 1, 19);

            Password password = new Password();
            Password = password.ReadPassword();

            Reporter?.SendReport(left + 1, 23);
            ConfirmPassword = password.ReadPassword();

            Reporter?.SendReport(left + 1, 27);
            Phone = Reporter?.SendReport();
        }
        #endregion

    }
}
