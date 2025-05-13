using WebApi.Data.Entities;

namespace WebApi.Services.Interfaces;

public interface IEventService
{
    public Task<IEnumerable<EventEntity>> GetAll();
}
