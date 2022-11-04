using MediatR;
using Microsoft.EntityFrameworkCore;
using RFT.Services.Extensions;
using RTF.Core.Extensions;
using RTF.Core.Repositories;
using RTF.CQS.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRequestHandlers();
builder.Services.AddDbContext<ConnectionContext>();
builder.Services.ConfigureCoreDependencies();
builder.Services.ConfigureServicesDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();