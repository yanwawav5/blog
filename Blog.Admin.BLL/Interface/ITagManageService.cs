using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Collections.Generic;

namespace Blog.Admin.BLL.Interface
{
    public interface ITagManageService
    {
        CommonResultDto<List<TagViewDto>> TagList();
    }
}
