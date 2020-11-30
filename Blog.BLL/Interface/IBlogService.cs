using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;

namespace Blog.BLL.Interface
{
    public interface IBlogService
    {
        CommonResultDto<List<BlogListViewDto>> BlogList(string keyword, int pageIndex, int pageSize);

        CommonResultDto<BlogViewDto> BlogDetail(string id);
    }
}
