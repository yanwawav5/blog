using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface IUserService
    {
        Task<CommonPageResultDto<UserViewDto>> UserList(string keyword, int pageIndex, int pageSize);
    }
}
