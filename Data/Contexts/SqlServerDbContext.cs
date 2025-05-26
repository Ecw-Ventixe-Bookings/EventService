using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<VenueEntity> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>().HasData(
            new CategoryEntity { Id = Guid.Parse("902C34D2-5A4D-43BE-82FD-98CE1CC927BB"), Name = "Music" },
            new CategoryEntity { Id = Guid.Parse("649D7A76-56A2-4342-A8BF-F3B95EF4C4F6"), Name = "Art" },
            new CategoryEntity { Id = Guid.Parse("A5DA6417-26F9-4B69-8365-010F0772F31F"), Name = "Comedy" });

        modelBuilder.Entity<VenueEntity>().HasData(
            new VenueEntity
            {
                Id = Guid.Parse("e1b5f8c0-0001-0000-0000-000000000001"),
                Name = "Stockholm Konserthus",
                Address = "Hötorget 8",
                PostalCode = "111 57",
                City = "Stockholm"
            },
            new VenueEntity
            {
                Id = Guid.Parse("e1b5f8c0-0002-0000-0000-000000000002"),
                Name = "Göteborgs Operan",
                Address = "Christina Nilssons Gata",
                PostalCode = "411 04",
                City = "Göteborg"
            },
            new VenueEntity
            {
                Id = Guid.Parse("e1b5f8c0-0003-0000-0000-000000000003"),
                Name = "Uppsala Konsert & Kongress",
                Address = "Vaksala torg 1",
                PostalCode = "753 31",
                City = "Uppsala"
            }
        );

        modelBuilder.Entity<EventEntity>().HasData(
            new EventEntity
            {
                Id = Guid.Parse("11111111-0001-0000-0000-000000000001"),
                Title = "Beethoven i Blå Hallen",
                Description = "En klassisk musikupplevelse med Stockholms filharmoniker.",
                StartDateTime = new DateTime(2025, 10, 12, 19, 0, 0),
                EndDateTime = new DateTime(2025, 10, 12, 21, 0, 0),
                TicketPrice = 350.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("902C34D2-5A4D-43BE-82FD-98CE1CC927BB"),
                VenueId = Guid.Parse("e1b5f8c0-0001-0000-0000-000000000001")
            },
            new EventEntity
            {
                Id = Guid.Parse("11111111-0002-0000-0000-000000000002"),
                Title = "Göteborgs Modern Art Expo",
                Description = "Utforska samtida konst från lokala och internationella konstnärer.",
                StartDateTime = new DateTime(2025, 9, 5, 10, 0, 0),
                EndDateTime = new DateTime(2025, 9, 5, 17, 0, 0),
                TicketPrice = 150.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("649D7A76-56A2-4342-A8BF-F3B95EF4C4F6"),
                VenueId = Guid.Parse("e1b5f8c0-0002-0000-0000-000000000002")
            },
            new EventEntity
            {
                Id = Guid.Parse("11111111-0003-0000-0000-000000000003"),
                Title = "Skrattfest med Anna Svensson",
                Description = "Standup-komedi av en av Sveriges roligaste röster.",
                StartDateTime = new DateTime(2025, 11, 1, 20, 0, 0),
                EndDateTime = new DateTime(2025, 11, 1, 22, 0, 0),
                TicketPrice = 220.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("A5DA6417-26F9-4B69-8365-010F0772F31F"),
                VenueId = Guid.Parse("e1b5f8c0-0003-0000-0000-000000000003")
            },
            new EventEntity
            {
                Id = Guid.Parse("11111111-0004-0000-0000-000000000004"),
                Title = "Jazzkväll i Uppsala",
                Description = "En intim kväll med svenska jazzlegender.",
                StartDateTime = new DateTime(2025, 8, 22, 18, 30, 0),
                EndDateTime = new DateTime(2025, 8, 22, 21, 0, 0),
                TicketPrice = 275.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("902C34D2-5A4D-43BE-82FD-98CE1CC927BB"),
                VenueId = Guid.Parse("e1b5f8c0-0003-0000-0000-000000000003")
            },
            new EventEntity
            {
                Id = Guid.Parse("11111111-0005-0000-0000-000000000005"),
                Title = "Digital Art Now",
                Description = "En utställning som fokuserar på AI och digital konst.",
                StartDateTime = new DateTime(2025, 12, 3, 11, 0, 0),
                EndDateTime = new DateTime(2025, 12, 3, 16, 0, 0),
                TicketPrice = 180.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("649D7A76-56A2-4342-A8BF-F3B95EF4C4F6"),
                VenueId = Guid.Parse("e1b5f8c0-0001-0000-0000-000000000001")
            },
            new EventEntity
            {
                Id = Guid.Parse("11111111-0006-0000-0000-000000000006"),
                Title = "Humorkväll med Jonas & Mia",
                Description = "Ett humoristiskt scenprogram med sketcher och improvisation.",
                StartDateTime = new DateTime(2025, 9, 18, 19, 30, 0),
                EndDateTime = new DateTime(2025, 9, 18, 21, 30, 0),
                TicketPrice = 200.00m,
                TotalTickets = 3500,
                CategoryId = Guid.Parse("A5DA6417-26F9-4B69-8365-010F0772F31F"),
                VenueId = Guid.Parse("e1b5f8c0-0002-0000-0000-000000000002")
            }
        );
    }
}