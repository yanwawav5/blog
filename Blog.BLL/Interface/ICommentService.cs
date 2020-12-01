using Blog.Dto;
using Blog.Dto.Blog;

namespace Blog.BLL.Interface
{
    public interface ICommentService
    {
        CommonPageResultDto<CommentViewDto> CommentList(string blogId, int pageIndex, int pageSize);

        CommonResultDto<string> Post(CommentAddDto dto);

        CommonResultDto<string> Update(CommentUpdateDto dto);
    }
}
