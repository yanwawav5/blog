using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Admin.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CommonPageResultDto<UserViewDto>> Get(string keyword, int pageIndex, int pageSize)
        {
            return await _userService.UserList(keyword, pageIndex, pageSize);
        }

       /// <summary>
       /// 用户注册
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<CommonResultDto<UserViewDto>> Register([FromBody]UserAddDto model)
        {
            return await _userService.Create(model);
        }

        
        [HttpPost]
        public async Task<CommonPageResultDto<UserViewDto>> Update(string keyword, int pageIndex, int pageSize)
        {
            return await _userService.UserList(keyword, pageIndex, pageSize);
        }
    }
}