using Blog.BLL.Interface;
using Blog.Dto;
using Blog.Dto.Blog;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.BLL.Service
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _context;
        public CommentService(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<CommonPageResultDto<CommentViewDto>> CommentList(string blogId, int pageIndex, int pageSize)
        {
            CommonPageResultDto<CommentViewDto> rlt = new CommonPageResultDto<CommentViewDto>();
            var qry = await (from a in _context.tbl_comment.Where(i => i.BlogId == blogId)
                             join b in _context.tbl_user
                             on a.From equals b.Id
                             join c in _context.tbl_user
                             on a.To equals c.Id into temp
                             from g in temp.DefaultIfEmpty()
                             select new CommentViewDto
                             {
                                 Id = a.Id,
                                 FromUserName = b.Name,
                                 ToUserName = g == null ? null : g.Name,
                                 CurrentFloorNum = a.CurrentFloorNum,
                                 ToFloorNum = a.ToFloorNum,
                                 CreateAt = a.CreateAt,
                                 Address = b.LastLoginAddr,
                                 LikeTimes = a.LikeTimes,
                                 Content = a.Content
                             }).ToListAsync();
            rlt.DataCount = qry.Count;
            rlt.Page = pageIndex;
            rlt.PageSize = pageSize;
            rlt.PageCount = (qry.Count + pageSize - 1) / pageSize;
            rlt.Data = qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rlt;
        }

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Post(CommentAddDto dto)
        {
            tbl_comment tbl = new tbl_comment
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = dto.BlogId,
                Content = dto.Content,
                From = dto.From,
                To = dto.To,
                CurrentFloorNum = dto.CurrentFloorNum,
                ToFloorNum = dto.ToFloorNum,
                CreateAt = DateTime.Now,
                LikeTimes = 0
            };
            await _context.tbl_comment.AddAsync(tbl);
            await _context.SaveChangesAsync();

            return new CommonResultDto<string> { Msg = "新增成功", Success = true };
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Like(string id)
        {
            tbl_comment tbl = await _context.tbl_comment.FirstOrDefaultAsync(i => i.Id == id);
            if(tbl != null)
            {
                ++tbl.LikeTimes;
            }
            _context.tbl_comment.Update(tbl);
            await _context.SaveChangesAsync();

            return new CommonResultDto<string> { Msg = "点赞成功", Success = true };
        }
    }
}
