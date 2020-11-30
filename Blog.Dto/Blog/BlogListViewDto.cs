using System;
using System.Collections.Generic;

namespace Blog.Dto.Blog
{
    public class BlogListViewDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public int ViewTimes { get; set; }
        public int CommentTimes { get; set; }
        public int LikeTimes { get; set; }
        public string PicUrl { get; set; }
        public List<TagViewDto> TagList { get; set; }
    }
}
