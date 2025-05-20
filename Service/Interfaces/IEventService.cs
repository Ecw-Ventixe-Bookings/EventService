using Service.Dtos;
using Service.Models;

namespace Service.Interfaces;

public interface IEventService
{
    Task<ServiceResult> CreateAsync(EventDto dto);
    Task<ServiceResult<EventModel>> GetByIdAsync(Guid id);
    Task<ServiceResult<IEnumerable<EventModel>>> GetAllAsync();
}