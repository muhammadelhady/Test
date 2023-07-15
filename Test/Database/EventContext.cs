using Bogus.DataSets;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Test.Models.Address;
using Test.Models.Event;
using Test.Models.Invitaion;
using Test.Models.User;

namespace Test.Database;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        var id = 101;
        var locations = new Faker<Location>()
            .RuleFor(l => l.Id, opt => id++)
            .RuleFor(l => l.CreatedOn, opt => DateTime.UtcNow)
            .RuleFor(l => l.CreatedBy, opt => opt.Name.FullName())
            .RuleFor(l => l.Langitude, opt => opt.Random.Number())
            .RuleFor(l => l.Latitude, opt => opt.Random.Number());

        modelBuilder.Entity<Location>().HasData(locations.GenerateBetween(100,100));
        id = 101;
        var companies = new Faker<Models.User.Company>()
                        .RuleFor(c => c.Id, opt => id++)
            .RuleFor(c => c.Name, opt => opt.Company.CompanyName())
            .RuleFor(c => c.Bs, opt => opt.Company.CompanyName())
            .RuleFor(c => c.CatchPhrase, opt => opt.Company.Random.Words())
            .RuleFor(c => c.CreatedBy, opt => opt.Name.FullName())
            .RuleFor(c => c.CreatedOn, opt => DateTime.UtcNow)
            .RuleFor(c => c.CatchPhrase, opt => opt.Company.Random.Words());
        modelBuilder.Entity<Models.User.Company>().HasData(companies.GenerateBetween(100, 100));


        id = 101;
        var addresses = new Faker<Models.Address.Address>()
            .RuleFor(a => a.Details, opt => opt.Address.Random.Word())
            .RuleFor(a => a.Suite, opt => opt.Address.Random.Word())
            .RuleFor(a => a.Street, opt => opt.Address.StreetName())
            .RuleFor(a => a.ZipCode, opt => opt.Address.ZipCode())
            .RuleFor(a => a.City, opt => opt.Address.City())
            .RuleFor(a => a.LocationId, opt => id)
            .RuleFor(a => a.Id, opt => id++)
            .RuleFor(a=>a.CreatedBy,opt=>opt.Name.FullName())
            .RuleFor(a=>a.CreatedOn,opt=>DateTime.UtcNow);
        modelBuilder.Entity<Models.Address.Address>().HasData(addresses.GenerateBetween(100, 100));
        id = 101;
        var users = new Faker<Models.User.User>()
            .RuleFor(u => u.CreatedOn, opt => DateTime.Now)
            .RuleFor(u => u.CreatedBy, opt => opt.Name.FullName())
            .RuleFor(u => u.Email, opt => opt.Internet.Email())
            .RuleFor(u => u.UserName, opt => opt.Internet.UserName())
            .RuleFor(u => u.Name, opt => opt.Name.FullName())
            .RuleFor(u => u.AddressId, opt => id)
            .RuleFor(u => u.phone, opt => opt.Phone.PhoneNumber())
            .RuleFor(u => u.CompanyId, opt => id)
            .RuleFor(u => u.WebSite, opt => opt.Internet.DomainWord())
            .RuleFor(u => u.Id, opt => id++);
       modelBuilder.Entity<User>().HasData(users.GenerateBetween(100, 100));
    }

    public DbSet<User> users { get; set; }
    public DbSet<Models.Address.Address> addresses { get; set; }
    public DbSet<Event> events { get; set; }
    public DbSet<Invitaion> invitaions { get; set; }
    public DbSet<Models.User.Company> companies { get; set; }
    public DbSet<Location> locations { get; set; }
}