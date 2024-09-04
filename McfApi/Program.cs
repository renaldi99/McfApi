using McfApi.Context;
using McfApi.Extensions;
using McfApi.Middleware;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection();
builder.Services.ConfigureCorsPolicy();
builder.Services.AddDbContext<EfCoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dev")));
builder.Services.AddTransient<HandleExceptionMiddleware>();

var app = builder.Build();
app.UseMiddleware<HandleExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "MCF REST API";
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();

