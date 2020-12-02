using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Admin.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagManageService _tagManageService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagManageService"></param>
        public TagController(ITagManageService tagManageService)
        {
            _tagManageService = tagManageService;
        }

        /// <summary>
        /// 博客标签列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<List<TagViewDto>>> Get()
        {
            return await _tagManageService.TagList();
        }
    }
}