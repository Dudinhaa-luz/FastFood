using FastFood.Api.Configurations;
using FastFood.Application.Interfaces.Services;
using FastFood.Application.Mappings;
using FastFood.Application.Services;
using FastFood.Application.Validators;
using FastFood.Domain.Interfaces.Repositories;
using FastFood.Infrastructure;
using FastFood.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ClientProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDependencies();


builder.Services.AddValidatorsFromAssemblyContaining<CreateClientRequestValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate(); // aplica as migrations pendentes
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/teste", () => "ok");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
