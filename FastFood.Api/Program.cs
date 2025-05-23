using FastFood.Api.Configurations;
using FastFood.Application.Mappings;
using FastFood.Application.Validators;
using FastFood.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ClientProfile));
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));


#region DI
DependencyInjection.AddDependencies(builder.Services);
#endregion

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
