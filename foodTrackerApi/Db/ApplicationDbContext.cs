using System;
using foodTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodTrackerApi.Db
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<FoodRecord> FoodRecords {get;set;}
    }
}