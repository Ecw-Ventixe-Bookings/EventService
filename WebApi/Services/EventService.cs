using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class EventService(AppDataContext context) : IEventService
{
    private readonly AppDataContext _context = context;

    public async Task<IEnumerable<EventEntity>> GetAll()
    {
        return await _context.Events.Include(x => x.Category).ToListAsync();
    }
}
