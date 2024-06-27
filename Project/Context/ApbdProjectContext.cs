using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Context;

public partial class ApbdProjectContext : DbContext
{
    public ApbdProjectContext()
    {
    }

    public ApbdProjectContext(DbContextOptions<ApbdProjectContext> options) : base(options)
    {
    }
    
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<IndividualClient> IndividualClients { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CompanyClient>(entity =>
        {
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.CompanyName).IsRequired();
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.Krs).IsRequired();
        });
        
        modelBuilder.Entity<IndividualClient>(entity =>
        {
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(32);
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(32);
            entity.Property(e => e.Pesel).IsRequired();
            entity.Property(e => e.Pesel).HasMaxLength(11);
        });
    }
}