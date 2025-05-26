using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;
}