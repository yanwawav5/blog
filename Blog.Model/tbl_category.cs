using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 博客类别表
    /// </summary>
    public class tbl_category
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("类别名称")]
        public string Name { get; set; }

        [Required, MaxLength(11)]
        [DisplayName("排序码")]
        public string Sequence { get; set; }

        [MaxLength(255)]
        [DisplayName("备注")]
        public string Remark { get; set; }
    }
}
