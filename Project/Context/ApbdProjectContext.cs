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
    public DbSet<AppUser> Users { get; set; }
    
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
            entity.Property(e => e.Price)
                .IsRequired()
                .HasPrecision(10, 2);
            entity.Property(e => e.IdSoftwareSystem).IsRequired();
            entity.Property(e => e.SoftwareSystemVersion)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxSoftwareSystemVersionLength);
            entity.Property(e => e.Updates)
                .IsRequired()
                .HasMaxLength(AppSettings.MaxContractUpdatesLength);
            entity.Property(e => e.IdClient)
                .IsRequired();
        });
        
        modelBuilder.Entity<AppUser> (entity =>
        {
            entity.HasKey(e => e.Login);

            entity.Property(e => e.Password).IsRequired();

            entity.Property(e => e.Roles).IsRequired();
        });
        
        modelBuilder.Entity<IndividualClient>().HasData(new List<IndividualClient>
        {
            new IndividualClient() {
                IdClient = 1,
                Address = "TestAddress",
                Email = "test@gmail.com",
                PhoneNumber = "123456789",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Pesel = "12345678901"
            }
        });
        modelBuilder.Entity<CompanyClient>().HasData(new List<CompanyClient>
        {
            new CompanyClient() {
                IdClient = 2,
                Address = "TestAddress",
                Email = "test@gmail.com",
                PhoneNumber = "123456789",
                CompanyName = "TestCompanyName",
                KrsNumber = "1234567890"
            }
        });
        
        modelBuilder.Entity<SoftwareSystem>().HasData(new List<SoftwareSystem>
        {
            new SoftwareSystem() {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Version = "1.0",
                Category = "TestCategory",
                YearlyPrice = 100
            },
            new SoftwareSystem() {
                Id = 2,
                Name = "TestName2",
                Description = "TestDescription2",
                Version = "2.0",
                Category = "TestCategory2",
                YearlyPrice = 200,
                Discounts = new List<Discount>()
            }
        });
        
        modelBuilder.Entity<Contract>().HasData(new List<Contract>
        {
            new Contract() {
                IdContract = 1,
                IdClient = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10),
                PreviousClientDiscount = true,
                Price = 100,
                IdSoftwareSystem = 1,
                SoftwareSystemVersion = "1.0",
                Updates = "TestUpdates"
            },
            new Contract() {
                IdContract = 2,
                IdClient = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10),
                Price = 200,
                IdSoftwareSystem = 2,
                SoftwareSystemVersion = "2.0",
                Updates = "TestUpdates2"
            }
        });
        
        
        modelBuilder.Entity<AppUser>().HasData(new List<AppUser>
        {
            new AppUser() {
                Login = "Employee",
                Password = "12345",
                Roles = "Employee"
            },
            new AppUser() {
                Login = "Admin",
                Password = "qwerty",
                Roles = "Admin,Employee"
            }
        });
    }
}