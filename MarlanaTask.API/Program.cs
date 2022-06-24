using MarlanaTask.API.Factories.Interfaces;
using MarlanaTask.BLL.Factories.Implementations;
using MarlanaTask.BLL.Factories.Interfaces;
using MarlanaTask.BLL.Services.Implementations;
using MarlanaTask.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task.BLL.Services.Implementations;
using Task.BLL.Services.Interfaces;
using Task.DAL.DbContexts;
using Task.DAL.Repositories.Implementations;
using Task.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyMethod()));

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyHeader()));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MarlanaTaskDbContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<ITasksBlockRepository, TasksBlockRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped<ITasksBlockService, TasksBlockService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IBlockAndTaskService, BlockAndTaskService>();

builder.Services.AddScoped<IDtoToEntityFactory, DtoToEntityFactory>();
builder.Services.AddScoped<IEntityToDtoFactory, EntityToDtoFactory>();

builder.Services.AddScoped<IModelToDtoFactory, ModelToDtoFactory>();
builder.Services.AddScoped<IDtoToModelFactory, DtoToModelFactory>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
