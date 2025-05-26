using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Service.Dtos;
using Service.Factories;
using Service.Interfaces;
using Service.Models;

namespace Service.Services;

public class EventService(IEventRepository eventRepository, IVenueRepository venueRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IVenueRepository _venueRepository = venueRepository;

    public async Task<ServiceResult> CreateAsync(EventDto dto)
    {
        var entity = EventFactory.Create(dto);
        var result = await _eventRepository.CreateAsync(entity);
        return new ServiceResult() { Success = result.Success, ErrorMessage = result.ErrorMessage };
    }

    public async Task<ServiceResult<EventModel>> GetByIdAsync(Guid id)
    {
        var eventResult = await _eventRepository.GetAsync(x => x.Id == id, query => query.Include(x => x.Category));
        if (!eventResult.Success) return new ServiceResult<EventModel>() { Success = false, ErrorMessage = eventResult.ErrorMessage};
        
        var venueResult = await _venueRepository.GetAsync(x => x.Id == eventResult.Data.VenueId);
        if (!venueResult.Success) return new ServiceResult<EventModel>() { Success = false, ErrorMessage = venueResult.ErrorMessage};
        
        var eventModel = EventFactory.Create(eventResult.Data);
        eventModel.Category = CategoryFactory.Create(eventResult.Data.Category);
        eventModel.Venue = VenueFactory.Create(venueResult.Data);
        
        return new ServiceResult<EventModel>() { Success = true, Data = eventModel };
    }
    
    public async Task<ServiceResult<IEnumerable<EventModel>>> GetAllAsync()
    {
        var entities = await _eventRepository.GetAllAsync(includes =>
            includes.Include(x => x.Category));

        if (!entities.Success)
        {
            return new ServiceResult<IEnumerable<EventModel>> { Success = false, ErrorMessage = "could not fetch the events from the database"};
        }
        
        var events = new List<EventModel>();

        foreach (var entity in entities.Data)
        {
            var venue = await _venueRepository.GetAsync(x => x.Id == entity.VenueId);
            var model = EventFactory.Create(entity);
            model.Venue = venue.Success ? VenueFactory.Create(venue.Data) : null;
            model.Category = CategoryFactory.Create(entity.Category);
            events.Add(model);
        }
        
        return new ServiceResult<IEnumerable<EventModel>> { Success = true, Data = events };
    }
}