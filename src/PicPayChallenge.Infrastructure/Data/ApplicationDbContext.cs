using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasSequence<int>("UserPublicIdSequence")
            .StartsAt(95720)
            .IncrementsBy(1);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}