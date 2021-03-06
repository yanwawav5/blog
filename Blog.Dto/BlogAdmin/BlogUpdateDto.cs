﻿using System.Collections.Generic;

namespace Blog.Dto.BlogAdmin
{
    public class BlogUpdateDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PicUrl { get; set; }
        public string CategoryId { get; set; }
        public List<string> TagIdList { get; set; }
    }
}
