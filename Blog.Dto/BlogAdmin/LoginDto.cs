using System.ComponentModel.DataAnnotations;

namespace Blog.Dto.BlogAdmin
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
