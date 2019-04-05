using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан логин пользователя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Недопустимая длина логина пользователя ")]
        [Display(Name ="Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени пользователя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано электронный адрес пользователя")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано пароль пользователя")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен быть не менее 8 символов")]
        [RegularExpression(@"^(?=.{8,})(?=.*\d)(?=.*[a-z])(?=/*[A-Z])(?!.*\s).*$",
            ErrorMessage = "Пароль должен состоять из заглавных и прописных букв, цифр, символов и знаков припинаний")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароли не совпадают")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повтор пароля")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано номер телефона пользователя")]
        [RegularExpression(@"^(\+[0-9]{11})$", ErrorMessage = "Номер телефона должен иметь формат +77xxxxxxxxx")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}