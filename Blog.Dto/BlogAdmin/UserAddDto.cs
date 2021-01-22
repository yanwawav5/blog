using System.ComponentModel.DataAnnotations;

namespace Blog.Dto.BlogAdmin
{
    public class UserAddDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
