using Blog.Dto;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Interface
{
    public interface IFileService
    {
        Task<CommonResultDto<string>> Upload(IFormFile file);
        Task<CommonResultDto<string>> Delete(string id);
    }
}
