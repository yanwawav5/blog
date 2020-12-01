using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.Admin.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        private IBlogManageService _blogManageService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="blogManageService"></param>
        public BlogController(ILogger<BlogController> logger, IBlogManageService blogManageService)
        {
            _logger = logger;
            _blogManageService = blogManageService;
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonPageResultDto<BlogListViewDto>> Get(string keyword, int pageIndex, int pageSize)
        {
            var rlt = await _blogManageService.BlogList(keyword, pageIndex, pageSize);

            return rlt;
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<CommonResultDto<string>> Delete(string id)
        {
            var rlt = await _blogManageService.Delete(id);

            return rlt;
        }

        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CommonResultDto<string>> Post(BlogAddDto dto)
        {
            var rlt = await _blogManageService.Post(dto);

            return rlt;
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<CommonResultDto<string>> Update(BlogUpdateDto dto)
        {
            var rlt = await _blogManageService.Update(dto);

            return rlt;
        }
    }
}
