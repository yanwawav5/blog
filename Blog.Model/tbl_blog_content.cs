using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 博客内容表
    /// </summary>
    public class tbl_blog_content
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(5000)]
        [DisplayName("博客内容")]
        public string Content { get; set; }
    }
}
