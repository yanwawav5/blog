using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.BLL.Interface
{
    public interface IBlogService
    {
        Task<CommonPageResultDto<BlogListViewDto>> BlogList(ConditionParamDto condition, int pageIndex, int pageSize);

        Task<CommonResultDto<List<TopBlogViewDto>>> TopBlogList();

        Task<CommonResultDto<BlogViewDto>> BlogDetail(string id);

        Task<CommonResultDto<string>> Like(string id);
    }
}
