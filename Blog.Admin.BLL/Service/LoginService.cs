using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Service
{
    public class LoginService: ILoginService
    {
        private readonly BlogContext _context;


        public LoginService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<tbl_user>> Login(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _context.tbl_user.SingleOrDefaultAsync(x => x.Name == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return new CommonResultDto<tbl_user>
            {
                Msg = "查询成功",
                Success = true,
                Response = user
            };
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
