using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = Guid.NewGuid(), FirstName = "Fred", LastName = "Flintstone", Email = "fred@bedrock.com", Mobile = "07 123 123 444", DateOfBirth = new DateTime(1980, 1, 4), Department = 4 },
            new Person { Id = Guid.NewGuid(), FirstName = "Wilma", LastName = "Flintstone", Email = "wilma@bedrock.com", Mobile = "07 123 123 123", DateOfBirth = new DateTime(1990, 1, 4), Department = 1 },
            new Person { Id = Guid.NewGuid(), FirstName = "Betty", LastName = "Rubble", Email = "betty@bedrock.com", Mobile = "07 123 123 124", DateOfBirth = new DateTime(1990, 2, 5), Department = 2 },
            new Person { Id = Guid.NewGuid(), FirstName = "Barney", LastName = "Rubble", Email = "barney@bedrock.com", Mobile = "07 123 123 125", DateOfBirth = new DateTime(1990, 3, 6), Department = 3 }
            );
    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }
}