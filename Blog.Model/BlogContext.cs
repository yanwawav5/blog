using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Model
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }

        public DbSet<tbl_blog> tbl_blog { get; set; }
        public DbSet<tbl_blog_content> tbl_blog_content { get; set; }
        public DbSet<tbl_blog_tag_relationship> tbl_blog_tag_relationship { get; set; }
        public DbSet<tbl_category> tbl_category { get; set; }
        public DbSet<tbl_comment> tbl_comment { get; set; }
        public DbSet<tbl_file> tbl_file { get; set; }
        public DbSet<tbl_tag> tbl_tag { get; set; }
        public DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                var configuration = builder.Build();
                optionsBuilder.UseMySql(configuration["Connection"]);
            }
        }
    }
}
