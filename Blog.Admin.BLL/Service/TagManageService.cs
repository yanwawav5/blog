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
    public class TagManageService:ITagManageService
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;
        public TagManageService(BlogContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommonResultDto<List<TagViewDto>>> TagList()
        {
            var data = await _context.tbl_tag.OrderBy(i => i.Sequence).Select(i => _mapper.Map<TagViewDto>(i)).ToListAsync();

            return new CommonResultDto<List<TagViewDto>>
            {
                Msg = "查询成功",
                Success = true,
                Response = data
            };
        }
    }
}
