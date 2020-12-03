using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;
        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查询博客分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResultDto<List<CategoryViewDto>>> CategoryList()
        {
            var list = await (from a in _context.tbl_blog
                             group a by a.CategoryId
                             into g
                             select new CategoryViewDto
                             {
                                 Id = g.Key,
                                 BlogCount = g.Count()
                             }).ToListAsync();
            var rlt = (from a in _context.tbl_category.ToList()
                       join b in list
                       on a.Id equals b.Id
                       select new CategoryViewDto
                       {
                          Id = a.Id,
                          BlogCount = b.BlogCount,
                          Name = a.Name,
                          Sequence = a.Sequence
                      }).ToList();

            return new CommonResultDto<List<CategoryViewDto>> { Msg = "查询成功", Success = true, Response = rlt };
        }
    }
}
