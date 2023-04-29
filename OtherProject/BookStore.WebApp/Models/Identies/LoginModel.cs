using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApp.Models.Identies
{
    public class LoginModel
    {
        [Required, Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; } = "";
        [Required, Display(Name = "Şifre")]
        public string Password { get; set; } = "";
        public bool RememberMe { get; set; }
    }

    public class RegisterUserModel
    {
        [Required, Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = "";
        [Required, EmailAddress, Display(Name ="E-Posta")]
        public string EMail { get; set; } = "";
        [Required, Display(Name = "Şifre")]
        public string Password { get; set; } = "";
    }
}
