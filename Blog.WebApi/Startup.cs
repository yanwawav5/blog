using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BLL.Interface;
using Blog.BLL.Service;
using Blog.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blog.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // swagger
            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "v1";
                config.ApiGroupNames = new[] { "v1" };
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Blog";
                    document.Info.Description = "Blog.WebApi";
                };
            });

            // connections
            services.AddDbContextPool<BlogContext>(options => options.UseMySql(Configuration["ConnectionString"]));

            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Ê¹ÓÃswagger
            app.UseOpenApi();
            app.UseSwaggerUi3();
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
