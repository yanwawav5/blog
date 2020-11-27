using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 博客标签关联表
    /// </summary>
    public class tbl_blog_tag_relationship
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("博客ID")]
        public string BlogId { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("标签ID")]
        public string TagId { get; set; }
    }
}
