using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.BLL.Interface
{
    public interface ITagService
    {
        Task<CommonResultDto<List<TagListDto>>> TagList();
    }
}
