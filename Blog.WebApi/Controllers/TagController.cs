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
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagService"></param>
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// 博客标签列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<List<TagListDto>>> Get()
        {
            return await _tagService.TagList();
        }
    }
}