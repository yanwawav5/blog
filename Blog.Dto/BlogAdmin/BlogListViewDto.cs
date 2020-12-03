using System;
using System.Collections.Generic;

namespace Blog.Dto.BlogAdmin
{
    public class BlogListViewDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? PublishAt { get; set; }
        public string CategoryName { get; set; }
        public List<string> TagNameList { get; set; }
        public string StateName { get; set; }
        public int ViewTimes { get; set; }
        public int LikeTimes { get; set; }
    }
}
