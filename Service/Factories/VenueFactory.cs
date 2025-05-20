using Data.Entities;
using Service.Models;

namespace Service.Factories;

public static class VenueFactory
{
    public static VenueModel Create(VenueEntity entity) =>
        new VenueModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            PostalCode = entity.PostalCode,
            City = entity.City
        };
}