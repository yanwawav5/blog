using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;

namespace Blog.BLL.Interface
{
    public interface ICategoryService
    {
        CommonResultDto<List<CategoryViewDto>> CategoryList();
    }
}
