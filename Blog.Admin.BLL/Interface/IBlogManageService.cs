using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface IBlogManageService
    {
        Task<CommonPageResultDto<BlogListViewDto>> BlogList(string keyword, int pageIndex, int pageSize);

        Task<CommonResultDto<BlogViewDto>> BlogDetail(string id);

        Task<CommonResultDto<string>> Post(BlogAddDto dto);

        Task<CommonResultDto<string>> Update(BlogUpdateDto dto);

        Task<CommonResultDto<string>> Delete(string id);

        Task<CommonResultDto<string>> ReleaseBlog(string id);
    }
}
