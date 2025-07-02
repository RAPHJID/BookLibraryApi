using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookLibraryApi;
using BookLibraryApi.Services;
using BookLibraryApi.Services.IService;
using BookLibraryApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//EFCore
builder.Services.AddDbContext<LibraryContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBookService, BookServices>();
builder.Services.AddScoped<IAuthorService, AuthorService>();


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
