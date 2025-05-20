using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class VenueRepository(SqlServerDbContext context) : BaseRepository<VenueEntity>(context), IVenueRepository
{
    
}