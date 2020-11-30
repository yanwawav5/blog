﻿namespace Blog.Dto
{
    /// <summary>
    /// 通用返回结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonResultDto<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; } = "服务器异常";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T Response { get; set; }
    }
}
