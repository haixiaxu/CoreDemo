using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repository;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace AccountOwnerServer.Extensions
{
    /// <summary>
    /// 服务扩展方法
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 配置Cors,Cors(跨资源共享)是一种机制,授予用户访问其他域中的服务器资源权限               
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
        /// <summary>
        /// 配置IIS集成, 不会初始化选项内的任何属性,因为可以使用默认值
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }
        /// <summary>
        /// 配置IOC容器添加记录器服务
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            //将在第一次请求服务是创建服务,然后每个后续请求都将调用该服务的相同实例,这意味着所有组件每次都需要共享相同的服务,始终使用同一实例
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //将为每个请求创建一次服务,这意味着每当向应用程序发送http请求时,都会创建服务的新实例
            //services.AddScoped<ILoggerManager, LoggerManager>();
            //每次应用程序请求时创建服务,如果在应用程序的一个请求中,多个组件需要该服务,则将为需要该服务的每个单个组件再次创建该服务
            //services.AddTransient<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// 配置数据库上下文服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:Context"];
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));

        }
        /// <summary>
        /// 配置仓储服务
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        /// <summary>
        /// 配置swagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountOwner API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}
