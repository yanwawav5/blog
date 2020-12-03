using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentService"></param>
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonPageResultDto<CommentViewDto>> CommentList(string blogId, int pageIndex, int pageSize)
        {
            return await _commentService.CommentList(blogId, pageIndex, pageSize);
        }

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CommonResultDto<string>> Post([FromBody]CommentAddDto dto)
        {
            return await _commentService.Post(dto);
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<CommonResultDto<string>> Update(string id)
        {
            return await _commentService.Update(id);
        }
    }
}