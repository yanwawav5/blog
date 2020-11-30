using Blog.Dto;
using Blog.Dto.BlogAdmin;
using System.IO;

namespace Blog.Admin.BLL.Interface
{
    public interface IFileService
    {
        CommonResultDto<string> Upload(File file);
    }
}
