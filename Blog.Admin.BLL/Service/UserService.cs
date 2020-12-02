using AutoMapper;
using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CommonPageResultDto<UserViewDto>> UserList(string keyword, int pageIndex, int pageSize)
        {
            CommonPageResultDto<UserViewDto> rlt = new CommonPageResultDto<UserViewDto>();
            var qry = await _context.tbl_user.Where(i => i.Name.Contains(keyword) || i.Email.Contains(keyword))
                .OrderBy(s => s.RegisterAt).Select(i => _mapper.Map<UserViewDto>(i)).ToListAsync();

            rlt.DataCount = qry.Count;
            rlt.Page = pageIndex;
            rlt.PageSize = pageSize;
            rlt.PageCount = (qry.Count + pageSize - 1) / pageSize;
            rlt.Data = qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rlt;
        }
    }
}
