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
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<IndividualClient> IndividualClients { get; set; }
    public DbSet<SoftwareSystem> SoftwareSystems { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.IdClient);
            
            entity.HasMany(c => c.Contracts)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.IdClient); 
        });
        
        modelBuilder.Entity<CompanyClient>(entity =>
        {
            
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

        modelBuilder.Entity<SoftwareSystem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(s => s.Discounts)
                .WithMany(d => d.SoftwareSystems);
            
            entity.HasMany(s => s.Contracts)
                .WithOne(c => c.SoftwareSystem)
                .HasForeignKey(c => c.IdSoftwareSystem);
            
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemNameLength);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemDescriptionLength);

            entity.Property(e => e.Version)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemVersionLength);

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemCategoryLength);
            
            entity.Property(e => e.YearlyPrice).IsRequired();
        });
        
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.IdDiscount);
            
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxDiscountNameLength);
            
            entity.Property(e => e.Percentage).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
        });
        
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract);
            
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.IdSoftwareSystem).IsRequired();
            entity.Property(e => e.SoftwareSystemVersion)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemVersionLength);
            entity.Property(e => e.Updates)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxContractUpdatesLength);
        });
    }
}