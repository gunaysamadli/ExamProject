using Exam.BLL.Mapping;
using Exam.DAL;
using Exam.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Exam.BLL.Services.Contracts;
using Exam.BLL.Services;
using Exam.BLL;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(assembly: Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDalServices();
builder.Services.AddBllServices();


builder.Services.AddScoped<ILessonService, LessonManager>();
//builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
