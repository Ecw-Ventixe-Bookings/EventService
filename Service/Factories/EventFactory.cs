using Data.Entities;
using Service.Dtos;
using Service.Models;

namespace Service.Factories;

public static class EventFactory
{
    public static EventDto Create() => new EventDto();

    public static EventEntity Create(EventDto dto) =>
        new EventEntity
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            StartDateTime = dto.StartDateTime,
            EndDateTime = dto.EndDateTime,
            TicketPrice = dto.TicketPrice,
            CategoryId = dto.CategoryId,
            VenueId = dto.VenueId,
        };

    public static EventModel Create(EventEntity entity) =>
        new EventModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDateTime = entity.StartDateTime,
            EndDateTime = entity.EndDateTime,
            TicketPrice = entity.TicketPrice
        };
}