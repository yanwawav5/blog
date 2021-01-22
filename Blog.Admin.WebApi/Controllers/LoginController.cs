using Blog.Admin.BLL.Interface;
using Blog.Admin.BLL.Service;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Admin.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private IConfiguration _configuration;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginService"></param>
        /// <param name="configuration"></param>
        public LoginController(LoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

       /// <summary>
       /// 登陆
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<CommonResultDto<object>> Login([FromBody]LoginDto model)
        {
            var user = await _loginService.Login(model.Username, model.Password);
            if (user == null)
                return new CommonResultDto<object>
                {
                    Msg = "登陆失败",
                    Success = false,
                    Response = "Username or password is incorrect"
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSetting:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Response.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return new CommonResultDto<object>
            {
                Msg = "登陆成功",
                Success = true,
                Response = new
                {
                    Id = user.Response.Id,
                    Name = user.Response.Name,
                    Token = tokenString
                }
            };
        }
    }
}