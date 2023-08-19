using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using TurnikeProje.BussinesLayer.ServiceRegistiration;
using TurnikeProje.DataAccessLayer.Contexts;
using TurnikeProje.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

using (var c = new AppDbContext())
{
    List<User> user = new List<User>()
    {
        new User(){Name="samet"},
        new User() {Name = "metin"},
        new User(){Name="feyza"},
        new User(){Name="halime"}
    };
    
    if (c.Users.Count() == 0 )
    {
        c.Users.AddRange(user);
        c.SaveChanges();
    }
   
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegisterRoutes();
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
