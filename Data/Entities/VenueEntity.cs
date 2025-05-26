using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class VenueEntity
{
    public Guid Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Address { get; set; } = null!;

    [StringLength(15)]
    public string PostalCode { get; set; } = null!;

    [StringLength(20)]
    public string City { get; set; } = null!;
}