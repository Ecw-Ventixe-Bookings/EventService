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
            Image = dto.Image,
            StartDateTime = dto.StartDateTime,
            EndDateTime = dto.EndDateTime,
            TicketPrice = dto.TicketPrice,
            TotalTickets = dto.TotalTickets,
            CategoryId = dto.CategoryId,
            VenueId = dto.VenueId,
        };

    public static EventModel Create(EventEntity entity) =>
        new EventModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Image = entity.Image,
            StartDateTime = entity.StartDateTime,
            EndDateTime = entity.EndDateTime,
            TicketPrice = entity.TicketPrice,
            TotalTickets = entity.TotalTickets,
        };
}