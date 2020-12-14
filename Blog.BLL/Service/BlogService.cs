using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.BLL.Service
{
    public class BlogService : IBlogService
    {
        private readonly BlogContext _context;
        public BlogService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查询博客列表
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<CommonPageResultDto<BlogListViewDto>> BlogList(ConditionParamDto condition, int pageIndex, int pageSize)
        {
            CommonPageResultDto<BlogListViewDto> rlt = new CommonPageResultDto<BlogListViewDto>();
            List<tbl_blog> list = new List<tbl_blog>();
            //if (!String.IsNullOrEmpty(condition.Keyword))
            //{
            //    list = await (from a in _context.tbl_blog.Where(i => i.Title.Contains(condition.Keyword))
            //                 join b in _context.tbl_blog_content.Where(i => i.Content.Contains(condition.Keyword))
            //                 on a.ContentId equals b.Id
            //                 select a).ToListAsync();
            //}
            if (!String.IsNullOrEmpty(condition.CategoryId))
            {
                list = _context.tbl_blog.Where(i => i.CategoryId == condition.CategoryId).ToList();
            }
            else if (!String.IsNullOrEmpty(condition.TagId))
            {
                list = (from a in _context.tbl_blog
                        join b in _context.tbl_blog_tag_relation.Where(i => i.TagId == condition.TagId)
                        on a.Id equals b.BlogId
                        select a).ToList();
            }
            else
            {
                list = await _context.tbl_blog.Where(i => i.DeleteAt == null).ToListAsync();
            }

            List<BlogListViewDto> commentGroup = await (from a in _context.tbl_comment
                                               group a by a.BlogId into g
                                               select new BlogListViewDto
                                               {
                                                   Id = g.Key,
                                                   CommentTimes = g.Count()
                                               }).ToListAsync();

            List<BlogListViewDto> qry = (from a in list
                                        join b in _context.tbl_blog_content
                                        on a.ContentId equals b.Id
                                        join c in _context.tbl_category
                                        on a.CategoryId equals c.Id
                                         join d in commentGroup
                                         on a.Id equals d.Id into temp
                                         from g in temp.DefaultIfEmpty()
                                         select new BlogListViewDto
                                        {
                                            Id = a.Id,
                                            Title = a.Title,
                                            Content = b.Content,
                                            CreateAt = a.CreateAt,
                                            ViewTimes = a.ViewTimes,
                                            LikeTimes = a.LikeTimes,
                                            PicUrl = a.PicUrl,
                                            CommentTimes = g == null ? 0 : g.CommentTimes // _context.tbl_comment.Count(i=>i.BlogId == a.Id)
                                        }).ToList();

            IQueryable<TagViewDto> tagRlt = (from a in _context.tbl_blog_tag_relation
                                            join b in _context.tbl_tag
                                            on a.TagId equals b.Id
                                            select new TagViewDto { BlogId = a.BlogId, TagName = b.Name, TagId = b.Id, Sequence = b.Sequence });

            qry = String.IsNullOrEmpty(condition.Keyword) ? qry : qry.Where(i => i.Title.Contains(condition.Keyword) || i.Content.Contains(condition.Keyword)).ToList();
            foreach (var item in qry)
            {
                item.TagList = await tagRlt.Where(i => i.BlogId == item.Id).Select(i => i).ToListAsync();
            }

            rlt.DataCount = qry.Count;
            rlt.Page = pageIndex;
            rlt.PageSize = pageSize;
            rlt.PageCount = (qry.Count + pageSize - 1) / pageSize;
            rlt.Data = qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rlt;
        }

        /// <summary>
        /// 查看博客详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<BlogViewDto>> BlogDetail(string id)
        {
            List<BlogListViewDto> commentGroup = await (from a in _context.tbl_comment
                                                        group a by a.BlogId into g
                                                        select new BlogListViewDto
                                                        {
                                                            Id = g.Key,
                                                            CommentTimes = g.Count()
                                                        }).ToListAsync();

            var qry =  (from g in commentGroup
                         join a in _context.tbl_blog.Where(i => i.DeleteAt == null)
                         on g.Id equals a.Id
                         join b in _context.tbl_blog_content
                         on a.ContentId equals b.Id
                         join c in _context.tbl_category
                         on a.CategoryId equals c.Id
                         where a.Id == id
                         select new BlogViewDto
                        {
                            Title = a.Title,
                            PicUrl = a.PicUrl,
                            Content = b.Content,
                            Remark = a.Remark,
                            CategoryName = c.Name,
                            CreateAt = a.CreateAt,
                            ViewTimes = a.ViewTimes,
                            LikeTimes = a.LikeTimes,
                            CommentTimes = g.CommentTimes//_context.tbl_comment.Count(i => i.BlogId == a.Id)
                        }).ToList();

            BlogViewDto rlt = qry.FirstOrDefault();
            IQueryable<TagViewDto> tagRlt = (from a in _context.tbl_blog_tag_relation
                                             join b in _context.tbl_tag
                                             on a.TagId equals b.Id
                                             select new TagViewDto { BlogId = a.BlogId, TagName = b.Name, TagId = b.Id, Sequence = b.Sequence });
            rlt.TagNameList = await tagRlt.Where(i => i.BlogId == id).Select(i => i.TagName).ToListAsync();


            //查看一次详情，浏览次数累加一次
            tbl_blog tbl = await _context.tbl_blog.FirstOrDefaultAsync(i => i.Id == id);
            if(tbl != null)
            {
                ++tbl.ViewTimes;
            }
            _context.tbl_blog.Update(tbl);
            await _context.SaveChangesAsync();

            return new CommonResultDto<BlogViewDto> { Msg = "查询成功", Success = true, Response = rlt };
        }

        /// <summary>
        /// 热门阅读列表
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResultDto<List<TopBlogViewDto>>> TopBlogList()
        {
            List<TopBlogViewDto> rlt = await _context.tbl_blog.OrderByDescending(i => (i.ViewTimes + i.LikeTimes))
                .Select(i => new TopBlogViewDto { Id = i.Id, Name = i.Title, ViewLikeTimes = i.ViewTimes + i.LikeTimes }).Take(5).ToListAsync();

            return new CommonResultDto<List<TopBlogViewDto>> { Msg = "查询成功", Success = true,Response = rlt };
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Like(string id)
        {
            tbl_blog tbl = await _context.tbl_blog.FirstOrDefaultAsync(i => i.Id == id);
            if (tbl != null)
            {
                ++tbl.LikeTimes;
            }
            _context.tbl_blog.Update(tbl);
            await _context.SaveChangesAsync();

            return new CommonResultDto<string> { Msg = "点赞成功", Success = true };
        }
    }
}
