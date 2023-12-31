﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=yorgun.1292;Host=localhost;Port=5432;Database=Turnikedb;");
        }

        public DbSet<Movement>Movements { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
