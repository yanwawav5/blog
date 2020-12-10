using AutoMapper;
using Blog.Admin.BLL.Interface;
using Blog.Admin.BLL.Service;
using Blog.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace Blog.Admin.WebApi
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
                    document.Info.Title = "BlogAdmin";
                    document.Info.Description = "Blog.Admin.WebApi";
                };
            });

            // connections
            services.AddDbContextPool<BlogContext>(options => options.UseMySql(Configuration["ConnectionString"]));

            services.AddScoped<IBlogManageService, BlogManageService>();
            services.AddScoped<ICategoryManageService, CategoryManageService>();
            services.AddScoped<ITagManageService, TagManageService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();

            //AutoMapper
            var allType =
                Assembly
                    .GetEntryAssembly()//获取默认程序集
                    .GetReferencedAssemblies()//获取所有引用程序集
                    .Select(Assembly.Load)
                    .SelectMany(y => y.DefinedTypes)
                    .Where(type => typeof(BLL.Mappers.MapperConfig).GetTypeInfo().IsAssignableFrom(type.AsType()));

            services.AddAutoMapper(allType.ToArray());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            #region 使用swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();
            #endregion

            // 解决跨域问题
            app.UseCors(builder => builder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
