using Blog.Dto;
using Blog.Model;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface ILoginService
    {
        Task<CommonResultDto<tbl_user>> Login(string username, string password);
    }
}
