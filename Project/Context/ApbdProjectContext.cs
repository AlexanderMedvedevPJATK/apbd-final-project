using Microsoft.EntityFrameworkCore;
using Project.Config;
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
            
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxAddressLength);
            
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxEmailLength);
            
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxPhoneNumberLength);
            
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxCompanyNameLength);
            
            entity.Property(e => e.KrsNumber)
                .IsRequired()
                .HasMaxLength(AppSettings.KrsLength);
        });
        
        modelBuilder.Entity<IndividualClient>(entity =>
        {
            entity.HasKey(e => e.IdClient);
            
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxAddressLength);
            
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxEmailLength);
            
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxPhoneNumberLength);
            
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxFirstNameLength);
            
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxLastNameLength);
            
            entity.Property(e => e.Pesel)
                .IsRequired()
                .HasMaxLength(AppSettings.PeselLength);
        });
    }
}