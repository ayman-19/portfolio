using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Implementations;
using Portfolio.Web.Implementations.Services;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PortfolioDbConnection"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonalInfoService, PersonalInfoService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<ISkillService, SkillService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
