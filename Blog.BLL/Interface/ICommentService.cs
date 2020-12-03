using Blog.Dto;
using Blog.Dto.Blog;
using System.Threading.Tasks;

namespace Blog.BLL.Interface
{
    public interface ICommentService
    {
        Task<CommonPageResultDto<CommentViewDto>> CommentList(string blogId, int pageIndex, int pageSize);

        Task<CommonResultDto<string>> Post(CommentAddDto dto);

        Task<CommonResultDto<string>> Like(string id);
    }
}
