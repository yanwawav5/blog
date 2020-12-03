using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blogService"></param>
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// 查询博客列表
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CommonPageResultDto<BlogListViewDto>> BlogList([FromBody]ConditionParamDto condition, int pageIndex, int pageSize)
        {
            return await _blogService.BlogList(condition, pageIndex, pageSize);
        }

        /// <summary>
        /// 查看博客详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<BlogViewDto>> BlogDetail(string id)
        {
            return await _blogService.BlogDetail(id);
        }

        /// <summary>
        /// 热门阅读列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<List<TopBlogViewDto>>> TopBlogList()
        {
            return await _blogService.TopBlogList();
        }
    }
}