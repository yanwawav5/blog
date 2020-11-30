using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dto.Blog
{
    public class CommentViewDto
    {
        public string Id { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public int CurrentFloorNum { get; set; }
        public int? ToFloorNum { get; set; }
        public DateTime CreateAt { get; set; }
        public string Address { get; set; }
        public int LikeTimes { get; set; }
        public string Conetnt { get; set; }
    }
}
