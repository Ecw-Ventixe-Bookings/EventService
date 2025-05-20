using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<VenueEntity> Venues { get; set; }
}