using Blog.Admin.BLL.Interface;
using Blog.Dto;
using Blog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Admin.BLL.Service
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        private readonly BlogContext _context;
        public FileService(IConfiguration configuration,BlogContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Upload(IFormFile file)
        {
            var path = Directory.GetCurrentDirectory() + _configuration["FilePath"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = path + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 10000).ToString() + Path.GetExtension(file.FileName);
            using (var stream = File.Create(filePath))
            {
                file.CopyTo(stream);
            }

            tbl_file tbl = new tbl_file
            {
                Id = Guid.NewGuid().ToString(),
                Name = file.FileName,
                Path = filePath,
                ExtName = Path.GetExtension(file.FileName),
                Size = file.Length,
                UploadAt = DateTime.Now,
                Type = '1'
            };

            await _context.tbl_file.AddAsync(tbl);
            await _context.SaveChangesAsync();
            return new CommonResultDto<string>
            {
                Msg = "上传成功",
                Success = true,
                Response = filePath
            };
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CommonResultDto<string>> Delete(string id)
        {
            tbl_file file = await _context.tbl_file.FirstOrDefaultAsync(i => i.Id == id);
            _context.tbl_file.Remove(file);

            if (File.Exists(file.Path))
            {
                File.Delete(file.Path);
            }
            await _context.SaveChangesAsync();

            return new CommonResultDto<string>
            {
                Msg = "删除成功",
                Success = true,
                Response = ""
            };
        }
    }
}
