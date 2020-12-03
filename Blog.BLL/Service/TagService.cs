using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Blog.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.BLL.Service
{
    public class TagService : ITagService
    {
        private readonly BlogContext _context;
        public TagService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResultDto<List<TagListDto>>> TagList()
        {
            var list = await (from a in _context.tbl_blog_tag_relation
                        group a by a.TagId
                        into g
                        select new TagListDto
                        {
                            TagId = g.Key,
                            BlogCount = g.Count()
                        }).ToListAsync();
            var rlt = (from a in _context.tbl_tag.ToList()
                       join b in list
                       on a.Id equals b.TagId
                       into temp 
                       from p in temp.DefaultIfEmpty()
                       select new TagListDto
                       {
                           TagId = a.Id,
                           TagName = a.Name,
                           Sequence = a.Sequence,
                           BlogCount = p == null ? 0 : p.BlogCount
                       }).ToList();

            return new CommonResultDto<List<TagListDto>> { Msg = "查询成功", Success = true, Response = rlt };
        }
    }
}
