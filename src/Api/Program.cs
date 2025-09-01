using Application.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ DbContext (EF Core)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// 3️⃣ MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

// 4️⃣ Controllers
builder.Services.AddControllers();

// 5️⃣ FluentValidation - modern approach
builder.Services.AddFluentValidationAutoValidation();  
builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectCommand>();

// 6️⃣ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 7️⃣ CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8️⃣ Enable CORS middleware
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();

app.Run();
