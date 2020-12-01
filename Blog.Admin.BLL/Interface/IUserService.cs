using Blog.Dto;
using Blog.Dto.BlogAdmin;

namespace Blog.Admin.BLL.Interface
{
    public interface IUserService
    {
        CommonPageResultDto<UserViewDto> UserList(string keyword, int pageIndex, int pageSize);
    }
}
