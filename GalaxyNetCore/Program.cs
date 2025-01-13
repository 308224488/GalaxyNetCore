// ���� Application ��Ľӿڣ����� IRepository<> �� IUnitOfWork
using GalaxyNetCore.Application.Shared.Interfaces;
// ���� Infrastructure ��Ĳִ�ʵ�֣����� Repository<> �� UnitOfWork
using GalaxyNetCore.Infrastructure.Repositories;
// ���� Entity Framework Core���������ݿ�����������
using Microsoft.EntityFrameworkCore;
// ���� Infrastructure ������ݷ��ʣ����� ApplicationDbContext
using GalaxyNetCore.Infrastructure.Data;
using GalaxyNetCore.Application.Shared.CommonServices;

var builder = WebApplication.CreateBuilder(args);

// �������ݿ������ģ�ʹ�� SQL Server ���������ļ��л�ȡ�����ַ���
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ע��ͨ�òִ��ӿ� IRepository<> ����ʵ�� Repository<>
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// ע�Ṥ����Ԫ�ӿ� IUnitOfWork ����ʵ�� UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//ע��Ӧ�ò����
builder.Services.AddApplicationServices();
// ��ӿ�������������ע������
builder.Services.AddControllers();

// ���� Swagger������ API �ĵ�����
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���ÿ�����Դ����CORS�����ԣ������κ���Դ��������ͷ��
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()   // �����κ���Դ
            .AllowAnyMethod()   // �����κ� HTTP ����
            .AllowAnyHeader();  // �����κ�ͷ��
    });
});

var app = builder.Build();

// ���� HTTP ����ܵ�

// ����ڿ��������У����� Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ���� HTTPS �ض���
app.UseHttpsRedirection();

// ���� CORS��ʹ��֮ǰ����� "AllowAll" ����
app.UseCors("AllowAll");

// ������֤�м���������������֤��
app.UseAuthentication();

// ������Ȩ�м��
app.UseAuthorization();

// ӳ�������·��
app.MapControllers();

// ����Ӧ�ó���
app.Run();
