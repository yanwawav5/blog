using Blog.Dto;
using Blog.Dto.Blog;
using System.Collections.Generic;

namespace Blog.BLL.Interface
{
    public interface ICommentService
    {
        CommonResultDto<List<CommentViewDto>> CommentList(string blogId, int pageIndex, int pageSize);

        CommonResultDto<string> Post(CommentAddDto dto);

        CommonResultDto<string> Update(CommentUpdateDto dto);
    }
}
