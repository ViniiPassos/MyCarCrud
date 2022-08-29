
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace MyCar.Model
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Car> Cars { get; set; }
    }
}
