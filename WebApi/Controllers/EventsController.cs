using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace WebApi.Controllers
{
    [ApiController]
    public class EventsController(IEventService service, ILogger<EventsController> logger) : ControllerBase
    {
        private readonly IEventService _service = service;
        private readonly ILogger<EventsController> _logger = logger;

        [HttpGet("/")]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _service.GetAllAsync();
            return events.Success 
                ? Ok(events) 
                : NotFound(events);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            _logger.LogInformation($"Incoming ID: {id}");
            
            var eventResult = await _service.GetByIdAsync(id);
            return eventResult.Success 
                ? Ok(eventResult) 
                : NotFound(eventResult);
        }
    }
}
