using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface ITagManageService
    {
        Task<CommonResultDto<List<TagViewDto>>> TagList();
    }
}
