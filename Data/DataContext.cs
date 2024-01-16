using CRUDUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUDUsuarios.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<PersonModel> Person { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().ToTable("person");
        }
    }
}
