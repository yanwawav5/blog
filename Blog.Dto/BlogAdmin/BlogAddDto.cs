using System.Collections.Generic;

namespace Blog.Dto.BlogAdmin
{
    public class BlogAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
        public string CategoryId { get; set; }
        public string PicUrl { get; set; }
        public string State { get; set; }
        public List<string> TagIdList { get; set; }
    }
}
