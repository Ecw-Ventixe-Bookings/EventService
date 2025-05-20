using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Service.Dtos;

public class EventDto
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

    [Precision(18, 2)]
    public decimal? TicketPrice { get; set; }


    public Guid CategoryId { get; set; }
    
    public Guid VenueId { get; set; }
}