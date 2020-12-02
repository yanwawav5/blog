using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Admin.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileService"></param>
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<CommonResultDto<string>> Upload([FromForm]IFormFile file)
        {
            return await _fileService.Upload(file);
        }

        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<CommonResultDto<string>> Delete(string id)
        {
            return await _fileService.Delete(id);
        }
    }
}