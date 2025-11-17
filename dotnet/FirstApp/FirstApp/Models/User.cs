

using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/", ErrorMessage = "Email pattern is wrong")]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contains 1 special character and so on...")]
        public string password { get; set; }

        [MaxLength(40)]
        [MinLength(10)]
        public string address { get; set; }

        [MaxLength(10)]
        [MinLength(4)]
        public string city { get; set; }
    }
}
