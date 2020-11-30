using System;
using System.Collections.Generic;

namespace Blog.Dto.Blog
{
    public class BlogViewDto
    {
        public string Title { get; set; }
        public string PicUrl { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
        public CategoryViewDto Category { get; set; }
        public List<TagViewDto> TagList { get; set; }
        public DateTime CreateAt { get; set; }
        public int ViewTimes { get; set; } 
        public int LikeTimes { get; set; } 
        public int CommentTimes { get; set; } 
    }
}
