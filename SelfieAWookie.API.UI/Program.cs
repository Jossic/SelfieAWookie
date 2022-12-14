using Microsoft.EntityFrameworkCore;
using SelfieAWookie.API.UI.ExtensionMethods;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SelfiesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDb")));
builder.Services.AddInjections();
builder.Services.AddControllers();
builder.Services.AddCustomSecurity();
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
app.UseCors(SecurityMethods.DEFAULT_POLICY);
app.UseAuthorization();

app.MapControllers();

app.Run();