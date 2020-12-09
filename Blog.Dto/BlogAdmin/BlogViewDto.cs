using System.Collections.Generic;

namespace Blog.Dto.BlogAdmin
{
    public class BlogViewDto
    {
        public string Title { get; set; }
        public string PicUrl { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
        public string Category { get; set; }
        public List<string> TagIdList { get; set; }
    }
}
