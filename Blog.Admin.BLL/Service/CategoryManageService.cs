using AutoMapper;
using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Service
{
    public class CategoryManageService : ICategoryManageService
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;
        public CategoryManageService(BlogContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommonResultDto<List<CategoryViewDto>>> CategoryList()
        {
            var data = await _context.tbl_category.OrderBy(s => s.Sequence).Select(i => _mapper.Map<CategoryViewDto>(i)).ToListAsync();

            return new CommonResultDto<List<CategoryViewDto>>
            {
                Msg = "查询成功",
                Success = true,
                Response = data
            };
        }
    }
}
