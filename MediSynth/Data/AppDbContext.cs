using Microsoft.EntityFrameworkCore;
using MediSynth.Models;
using System.Collections.Generic;

namespace MediSynth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}