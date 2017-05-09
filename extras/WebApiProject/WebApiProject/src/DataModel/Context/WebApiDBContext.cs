using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataModel.Data.Model;

namespace DataModel.Data.Context
{
    public class WebApiDBContext : DbContext
    {
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Token>().ToTable("Tokens");
            modelBuilder.Entity<Users>().ToTable("User");
        }
    }
}
