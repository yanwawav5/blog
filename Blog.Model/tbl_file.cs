using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 附件表
    /// </summary>
    public class tbl_file
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("文件名")]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("文件路径")]
        public string Path { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("文件后缀名")]
        public string ExtName { get; set; }

        [Required]
        [DisplayName("文件大小")]
        public double Size { get; set; }

        [Required]
        [DisplayName("上传时间")]
        public DateTime UploadAt { get; set; }

        [Required, MaxLength(1)]
        [DisplayName("文件类型（1：博客图片:2：用户头像）")]
        public char Type { get; set; }
    }
}
