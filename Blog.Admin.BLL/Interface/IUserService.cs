using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Blog.Model;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface IUserService
    {
        Task<CommonPageResultDto<UserViewDto>> UserList(string keyword, int pageIndex, int pageSize);

        Task<CommonResultDto<UserViewDto>> GetById(string id);

        Task<CommonResultDto<UserViewDto>> Create(UserAddDto user);
    }
}
