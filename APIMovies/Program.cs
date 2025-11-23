using APIMovies.DAL;
using APIMovies.MoviesMapper;
using APIMovies.Repository;
using APIMovies.Repository.IRepository;
using APIMovies.Services;
using APIMovies.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());

// repositories 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// services 
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// 22/11/2025 - Terminamos clase 3, continuamos Clase 3.1(bonus)--