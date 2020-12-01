using Blog.Dto;
using Blog.Dto.Blog;

namespace Blog.BLL.Interface
{
    public interface IBlogService
    {
        CommonPageResultDto<BlogListViewDto> BlogList(string keyword, int pageIndex, int pageSize);

        CommonResultDto<BlogViewDto> BlogDetail(string id);
    }
}
