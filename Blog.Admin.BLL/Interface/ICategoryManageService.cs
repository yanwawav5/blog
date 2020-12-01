using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface ICategoryManageService
    {
        Task<CommonResultDto<List<CategoryViewDto>>> CategoryList();
    }
}
