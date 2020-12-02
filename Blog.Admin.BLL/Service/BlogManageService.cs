using Blog.Dto;
using Blog.Dto.BlogAdmin;
using Blog.Admin.BLL.Interface;
using System;
using System.Collections.Generic;
using Blog.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.Admin.BLL.Service
{
    public class BlogManageService : IBlogManageService
    {
        private readonly BlogContext _context;
        public BlogManageService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查询博客列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<CommonPageResultDto<BlogListViewDto>> BlogList(string keyword, int pageIndex, int pageSize)
        {
            CommonPageResultDto<BlogListViewDto> rlt = new CommonPageResultDto<BlogListViewDto>();
            List<BlogListViewDto> qry = await (from a in _context.tbl_blog.Where(i=>i.Title.Contains(keyword)) 
                                         join b in _context.tbl_blog_content.Where(i=>i.Content.Contains(keyword)) 
                                         on a.ContentId equals b.Id
                                         join c in _context.tbl_category 
                                         on a.CategoryId equals c.Id
                                         where a.DeleteAt == null
                                         select new BlogListViewDto
                                         {
                                             Id = a.Id,
                                             Title = a.Title,
                                             CreateAt = a.CreateAt,
                                             PublishAt = a.PublishAt,
                                             CategoryName = c.Name,
                                             StateName = a.State == '1' ? "未发布" : "已发布",
                                             ViewTimes = a.ViewTimes,
                                             LikeTimes = a.LikeTimes
                                         }).ToListAsync();

            IQueryable<BlogTagQryDto> tagRlt = (from a in _context.tbl_blog_tag_relationship
                         join b in _context.tbl_tag
                         on a.TagId equals b.Id
                         select new BlogTagQryDto { BlogId = a.BlogId, TagName = b.Name });
            foreach (var item in qry)
            {
                item.TagNameList = await tagRlt.Where(i => i.BlogId == item.Id).Select(i => i.TagName).ToListAsync();
            }
            rlt.DataCount = qry.Count;
            rlt.Page = pageIndex;
            rlt.PageSize = pageSize;
            rlt.PageCount = (qry.Count + pageSize - 1) / pageSize;
            rlt.Data = qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rlt;
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Delete(string id)
        {
            tbl_blog tbl = await _context.tbl_blog.FirstOrDefaultAsync(i=>i.Id == id);
            tbl.DeleteAt = DateTime.Now;
            _context.tbl_blog.Update(tbl);
            await _context.SaveChangesAsync();

            return new CommonResultDto<string> { Msg = "更新成功", Success = true };
        }

        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Post(BlogAddDto dto)
        {
            using (await _context.Database.BeginTransactionAsync())
            {
                System.ComponentModel.NullableConverter nullableDateTime = new System.ComponentModel.NullableConverter(typeof(DateTime?));
                string blogContentId = Guid.NewGuid().ToString();
                string blogId = Guid.NewGuid().ToString();
                tbl_blog_content tbl_content = new tbl_blog_content
                {
                    Id = blogContentId,
                    Content = dto.Content
                };

                tbl_blog tbl_blog = new tbl_blog
                {
                    Id = blogId,
                    Title = dto.Title,
                    ContentId = blogContentId,
                    Remark = dto.Remark,
                    CategoryId = dto.CategoryId,
                    PicUrl = dto.PicUrl,
                    ViewTimes = 0,
                    LikeTimes = 0,
                    State = dto.State == "1" ? '1' : '2', //状态（枚举类型 1未发布 2已发布）
                    CreateAt = DateTime.Now,
                    PublishAt = dto.State == "2" ? DateTime.Now : (DateTime?)nullableDateTime.ConvertFromString(null),
                    DeleteAt = null
                };

                List<tbl_blog_tag_relationship> relationList = new List<tbl_blog_tag_relationship>();
                foreach (var item in dto.TagIdList)
                {
                    relationList.Add(new tbl_blog_tag_relationship
                    {
                        Id = Guid.NewGuid().ToString(),
                        BlogId = blogId,
                        TagId = item
                    });
                }

                await _context.tbl_blog.AddAsync(tbl_blog);
                await _context.tbl_blog_content.AddAsync(tbl_content);
                await _context.tbl_blog_tag_relationship.AddRangeAsync(relationList);
                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();

                return new CommonResultDto<string> { Msg = "新增成功", Success = true };
            }
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Update(BlogUpdateDto dto)
        {
            using(await _context.Database.BeginTransactionAsync())
            {

            }
            throw new NotImplementedException();
        }
    }
}
