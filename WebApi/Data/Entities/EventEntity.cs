using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities;

public class EventEntity
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    [Required]
    public string VenueAddress { get; set; } = null!;

    public int? MaxAttendees { get; set; }

    public int? CurrentAttendeesCount { get; set; }

    [Precision(18, 2)]
    public decimal? TicketPrice { get; set; }


    public Guid CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
}

