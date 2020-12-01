using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.BLL.Interface
{
    public interface ICategoryService
    {
        Task<CommonResultDto<List<CategoryViewDto>>> CategoryList();
    }
}
