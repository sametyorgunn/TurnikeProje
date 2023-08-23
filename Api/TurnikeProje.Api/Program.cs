using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Text;
using TurnikeProje.BussinesLayer.ServiceRegistiration;
using TurnikeProje.DataAccessLayer.Contexts;
using TurnikeProje.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

using (var c = new AppDbContext())
{
    List<User> user = new List<User>()
    {
        new User(){Name="samet",Surname="yorgun",Mail="asametyorgun@gmail.com",Password="1234"},
        new User() {Name = "metin",Surname="yorgun",Mail="asametyorgun@gmail.com",Password="1234"},
        new User(){Name="feyza",Surname="yorgun",Mail="asametyorgun@gmail.com",Password="1234"},
        new User(){Name="halime",Surname="yorgun",Mail="asametyorgun@gmail.com",Password="1234"}
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoresecuritykeykey")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
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
