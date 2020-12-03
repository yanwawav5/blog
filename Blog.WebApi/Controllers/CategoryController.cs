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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryService"></param>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 查询博客分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonResultDto<List<CategoryViewDto>>> CategoryList()
        {
            return await _categoryService.CategoryList();
        }
    }
}