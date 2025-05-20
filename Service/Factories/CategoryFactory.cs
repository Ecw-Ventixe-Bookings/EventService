using Data.Entities;
using Service.Models;

namespace Service.Factories;

public static class CategoryFactory
{
    public static CategoryModel Create(CategoryEntity entity) =>
        new CategoryModel()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
}