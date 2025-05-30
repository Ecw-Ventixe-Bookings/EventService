using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class EventRepository(SqlServerDbContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
}