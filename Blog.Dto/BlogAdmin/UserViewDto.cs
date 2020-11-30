using System;

namespace Blog.Dto.BlogAdmin
{
    public class UserViewDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterAt { get; set; }
        public DateTime LastLoginAt { get; set; }
        public string LastLoginAddress { get; set; }
    }
}
