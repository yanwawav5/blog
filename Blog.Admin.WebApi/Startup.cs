using AutoMapper;
using Blog.Admin.BLL.Interface;
using Blog.Admin.BLL.Service;
using Blog.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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


            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(Configuration["AppSetting:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = context.Principal.Identity.Name;
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IBlogManageService, BlogManageService>();
            services.AddScoped<ICategoryManageService, CategoryManageService>();
            services.AddScoped<ITagManageService, TagManageService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();

            //AutoMapper
            //var allType =
            //    Assembly
            //        .GetEntryAssembly()//��ȡĬ�ϳ���
            //        .GetReferencedAssemblies()//��ȡ�������ó���
            //        .Select(Assembly.Load)
            //        .SelectMany(y => y.DefinedTypes)
            //        .Where(type => typeof(BLL.Mappers.MapperConfig).GetTypeInfo().IsAssignableFrom(type.AsType()));

            //services.AddAutoMapper(allType.ToArray());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            #region ʹ��swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();
            #endregion

            // �����������
            app.UseCors(builder => builder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
