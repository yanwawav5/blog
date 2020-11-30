using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;

namespace Blog.BLL.Interface
{
    public interface ITagService
    {
        CommonResultDto<List<TagViewDto>> TagList();
    }
}
