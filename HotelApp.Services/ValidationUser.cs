using Hotel.Services.Abstract;
using HotelApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Services
{
    public class ValidationUser
    {
        public IReporter Reporter { get; set; }
        public void Validation()
        {
            User user;
            ConsoleApp console = new ConsoleApp()
            {
                Reporter = new ConsoleReporter()
            };

            while (true)
            {
                console.DisplayRegistrationWindow();

                user = new User
                {
                    Login = console.Login,
                    Name = console.Name,
                    Email = console.Email,
                    Phone = console.Phone,
                    Password = console.Password,
                    ConfirmPassword = console.ConfirmPassword
                };

                var results = new List<ValidationResult>();
                
                var context = new ValidationContext(user);
                if (!Validator.TryValidateObject(user, context, results, true))
                {
                    System.Console.Clear();
                    Reporter?.SendReport("Ошибки:");
                    for (int i = 0; i < results.Count; i++)
                    {
                        Reporter?.SendReport(i + 1 + ". " + results[i].ErrorMessage);
                    }
                    Reporter?.SendReport("\nнажмите любую кнопку для продолжения...");
                    Reporter?.SendReport();
                    System.Console.Clear();
                }
                else
                {
                    SmsVerification verification = new SmsVerification();
                    string adoptedCode = verification.VerificationAccount();
                    bool enterCode = false;
                    while (enterCode == false)
                    {
                        Reporter?.SendReport("Введите полученый код");
                        string verificationCode = Reporter?.SendReport();

                        if (adoptedCode == verificationCode)
                        {
                            Reporter?.SendReport("Поздравляю Вы прошли верификацию!!!");
                            enterCode = true;
                        }

                        else
                        {
                            Reporter?.SendReport("Попробуйте снова");
                        }
                    }
                    break;
                }
            }
            Reporter?.SendReport();
        }
    }
}
