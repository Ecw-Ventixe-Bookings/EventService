using Data.Entities;

namespace Service.Models;

public class EventModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image {  get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public decimal? TicketPrice { get; set; }
    public int TotalTickets { get; set; }
    
    public CategoryModel Category { get; set; }
    public VenueModel? Venue { get; set; }
}