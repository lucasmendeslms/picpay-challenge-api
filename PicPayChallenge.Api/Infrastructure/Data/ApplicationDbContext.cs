using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Api.Model.Entities;

namespace PicPayChallenge.Api.Config.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<IndividualUser> IndividualUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}