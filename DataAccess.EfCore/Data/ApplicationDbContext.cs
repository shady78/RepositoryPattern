using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCore.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure default value SQL for new entities
        modelBuilder.Entity<Developer>()
            .Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Project>()
            .Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Customer>()
            .Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        // Use static GUIDs for seeding data
        modelBuilder.Entity<Developer>().HasData(
            new Developer
            {
                Id = new Guid("5fa503ba-4510-41b4-a5cc-8fa54e532e17"),
                Name = "John Doe",
                Followers = 100
            },
            new Developer
            {
                Id = new Guid("93d3ce8e-a58a-41eb-843f-59336600e5ab"),
                Name = "Jane Doe",
                Followers = 200
            }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = new Guid("522c9221-0e98-4b9f-b6ea-473bd01774d0"),
                Name = "Project 1"
            },
            new Project
            {
                Id = new Guid("b544d7ae-1eb8-4fc9-81e4-f63e32c2caf3"),
                Name = "Project 2"
            }
        );
    }
}
