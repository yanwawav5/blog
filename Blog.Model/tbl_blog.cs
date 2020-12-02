using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 博客表
    /// </summary>
    public class tbl_blog
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("博客标题")]
        public string Title { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("内容ID")]
        public string ContentId { get; set; }

        [MaxLength(500)]
        [DisplayName("备注")]
        public string Remark { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("类别ID")]
        public string CategoryId { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("博客图片路径")]
        public string PicUrl { get; set; }

        [Required, MaxLength(11)]
        [DisplayName("浏览次数")]
        public int ViewTimes { get; set; }

        [Required, MaxLength(11)]
        [DisplayName("点赞次数")]
        public int LikeTimes { get; set; }

        [Required, MaxLength(1)]
        [DisplayName("状态（枚举类型 1未发布 2已发布）")]
        public char State { get; set; }

        [Required]
        [DisplayName("创建时间")]
        public DateTime CreateAt { get; set; }

        [DisplayName("发布时间")]
        public DateTime? PublishAt { get; set; }

        [DisplayName("修改时间")]
        public DateTime? UpdateAt { get; set; }

        [DisplayName("datetime")]
        public DateTime? DeleteAt { get; set; }
    }
}
