using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class tbl_user
    {
        [Required, MaxLength(36)]
        [DisplayName("主键ID")]
        public string Id { get; set; }

        [Required, MaxLength(16)]
        [DisplayName("用户名")]
        public string Name { get; set; }

        [Required, MaxLength(64)]
        [DisplayName("邮箱地址")]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("密码加密密文")]
        public string Password { get; set; }

        [Required]
        [DisplayName("注册时间")]
        public DateTime RegisterAt { get; set; }

        [Required]
        [DisplayName("最后一次登录时间")]
        public DateTime LastLoginAt { get; set; }

        [Required, MaxLength(255)]
        [DisplayName("最后一次登陆地点")]
        public string LastLoginAddr { get; set; }
    }
}
