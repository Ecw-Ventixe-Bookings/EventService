using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class EventEntity
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(2000)]
    public string? Description { get; set; }

    public string? Image {  get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Precision(18, 2)]
    public decimal? TicketPrice { get; set; }

    public int TotalTickets { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    
    public Guid VenueId { get; set; }
}