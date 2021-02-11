using MyHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHouse.Database
{
    public class AppDbContext: DbContext
    {


        public AppDbContext() : base("Atheer")
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<MaritualStatus> MaritualStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
    }
}