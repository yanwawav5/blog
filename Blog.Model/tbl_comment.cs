using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 评论内容表
    /// </summary>
    public class tbl_comment
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("博客ID")]
        public string BlogId { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("评论内容")]
        public string Content { get; set; }

        [Required, MaxLength(36)]
        [DisplayName("评论人ID")]
        public string From { get; set; }

        [MaxLength(36)]
        [DisplayName("被评论人ID")]
        public string To { get; set; }

        [Required]
        [DisplayName("评论时间")]
        public DateTime CreateAt { get; set; }

        [Required, MaxLength(11)]
        [DisplayName("点赞次数")]
        public int LikeTimes { get; set; }

        [Required, MaxLength(11)]
        [DisplayName("当前评论楼层数")]
        public int CurrentFloorNum { get; set; }

        [MaxLength(11)]
        [DisplayName("被评论人所处评论楼层数")]
        public int? ToFloorNum { get; set; }
    }
}
