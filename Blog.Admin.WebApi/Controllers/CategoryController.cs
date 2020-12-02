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
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManageService _categoryManageService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryManageService"></param>
        public CategoryController(ICategoryManageService categoryManageService)
        {
            _categoryManageService = categoryManageService;
        }

        /// <summary>
        /// 博客类别列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<List<CategoryViewDto>>> Get()
        {
            return await _categoryManageService.CategoryList();
        }
    }
}