using AutoMapper;
using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Service
{
    public class UserService:IUserService
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;
        public UserService(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<CommonPageResultDto<UserViewDto>> UserList(string keyword, int pageIndex, int pageSize)
        {
            CommonPageResultDto<UserViewDto> rlt = new CommonPageResultDto<UserViewDto>();
            var qry = await _context.tbl_user.OrderBy(s => s.RegisterAt).Select(i => _mapper.Map<UserViewDto>(i)).ToListAsync();

            qry = String.IsNullOrEmpty(keyword) ? qry : qry.Where(i => i.Name.Contains(keyword) || i.Email.Contains(keyword)).ToList();
            rlt.DataCount = qry.Count;
            rlt.Page = pageIndex;
            rlt.PageSize = pageSize;
            rlt.PageCount = (qry.Count + pageSize - 1) / pageSize;
            rlt.Data = qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rlt;
        }

        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<UserViewDto>> GetById(string id)
        {
            return new CommonResultDto<UserViewDto>
            {
                Msg = "查询成功",
                Success = true,
                Response = await _context.tbl_user.Where(i => i.Id == id).Select(i => _mapper.Map<UserViewDto>(i)).FirstOrDefaultAsync()
            };
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<UserViewDto>> Create(UserAddDto user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Password is required");

            if (_context.tbl_user.Any(x => x.Name == user.Name))
                throw new Exception("Username \"" + user.Name + "\" is already 存在");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            tbl_user tbl = new tbl_user
            {
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                RegisterAt = DateTime.Now,
                LastLoginAt = DateTime.Now,
                LastLoginAddr = "",
                Type = '2',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.tbl_user.AddAsync(tbl);
            _context.SaveChanges();

            return new CommonResultDto<UserViewDto>
            {
                Msg = "查询成功",
                Success = true,
                Response = new UserViewDto { 
                    Id = tbl.Id, 
                    Name = tbl.Name, 
                    Email = tbl.Email, 
                    LastLoginAddr = tbl.LastLoginAddr,
                    LastLoginAt = tbl.LastLoginAt,
                    RegisterAt = tbl.RegisterAt
                }
            };
        }

        public void Update(tbl_user userParam, string password = null)
        {
            var user = _context.tbl_user.Find(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Name) && userParam.Name != user.Name)
            {
                // throw error if the new username is already taken
                if (_context.tbl_user.Any(x => x.Name == userParam.Name))
                    throw new Exception("Name " + userParam.Name + " is already taken");

                user.Name = userParam.Name;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.Name))
                user.Name = userParam.Name;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.tbl_user.Update(user);
            _context.SaveChanges();
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
