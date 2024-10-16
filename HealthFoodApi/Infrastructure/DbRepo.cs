﻿using HealthFoodApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthFoodApi.Infrastructure
{
    public class DbRepo : DbContext
    {
        public DbRepo(DbContextOptions<DbRepo> options) : base(options) { }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodPhoto> FoodPhoto { get; set; }
        public DbSet<Calories> Calories { get; set; }

    }
}
