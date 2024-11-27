using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext(DbContextOptions<PersonManagerContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(m => m.Employees)
            .HasForeignKey(e => e.ManagerId);
    }

    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Manager> Managers { get; set; } = null!;
    public DbSet<PayBand> PayBands { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
}
