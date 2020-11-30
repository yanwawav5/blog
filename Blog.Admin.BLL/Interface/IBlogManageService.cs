using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Collections.Generic;

namespace Blog.Admin.BLL.Interface
{
    public interface IBlogManageService
    {
        CommonResultDto<List<BlogListViewDto>> BlogList(string keyword, int pageIndex, int pageSize);

        CommonResultDto<string> Post(BlogAddDto dto);

        CommonResultDto<string> Update(BlogUpdateDto dto);

        CommonResultDto<string> Delete(string id);
    }
}
