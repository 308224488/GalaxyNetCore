// 引用 Application 层的接口，包括 IRepository<> 和 IUnitOfWork
using GalaxyNetCore.Application.Shared.Interfaces;
// 引用 Infrastructure 层的仓储实现，包括 Repository<> 和 UnitOfWork
using GalaxyNetCore.Infrastructure.Repositories;
// 引用 Entity Framework Core，用于数据库上下文配置
using Microsoft.EntityFrameworkCore;
// 引用 Infrastructure 层的数据访问，包括 ApplicationDbContext
using GalaxyNetCore.Infrastructure.Data;
using GalaxyNetCore.Application.Shared.CommonServices;

var builder = WebApplication.CreateBuilder(args);

// 配置数据库上下文，使用 SQL Server 并从配置文件中获取连接字符串
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 注册通用仓储接口 IRepository<> 和其实现 Repository<>
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 注册工作单元接口 IUnitOfWork 和其实现 UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//注册应用层服务
builder.Services.AddApplicationServices();
// 添加控制器服务到依赖注入容器
builder.Services.AddControllers();

// 配置 Swagger，用于 API 文档生成
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 配置跨域资源共享（CORS）策略，允许任何来源、方法和头部
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()   // 允许任何来源
            .AllowAnyMethod()   // 允许任何 HTTP 方法
            .AllowAnyHeader();  // 允许任何头部
    });
});

var app = builder.Build();

// 配置 HTTP 请求管道

// 如果在开发环境中，启用 Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 启用 HTTPS 重定向
app.UseHttpsRedirection();

// 启用 CORS，使用之前定义的 "AllowAll" 策略
app.UseCors("AllowAll");

// 启用认证中间件（如果有配置认证）
app.UseAuthentication();

// 启用授权中间件
app.UseAuthorization();

// 映射控制器路由
app.MapControllers();

// 运行应用程序
app.Run();
