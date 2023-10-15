using System.ComponentModel.DataAnnotations;

namespace WEB.API.Jarvis.Models.Authentication.Login
{
    public class StudentLoginModel
    {
        public string? ID { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
