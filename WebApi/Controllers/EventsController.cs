using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService service) : ControllerBase
    {
        private readonly IEventService _service = service;

        [HttpGet("/")]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                var events = await _service.GetAll();
                return Ok(events);
            }
            catch 
            {
                return Problem("Database not responding");
            }
        }
    }
}
