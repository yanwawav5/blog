using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Collections.Generic;

namespace Blog.Admin.BLL.Interface
{
    public interface ICategoryManageService
    {
        CommonResultDto<List<CategoryViewDto>> CategoryList();
    }
}
