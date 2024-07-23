using EventCore_Api.Dtos.EventsDtos;
using EventCore_Api.Repositories.EventRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EventCore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventsDto>>> GetAllEvents()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventsDto>> GetEventById(int id)
        {
            var eventDto = await _eventRepository.GetEventByIdAsync(id);
            if (eventDto == null)
            {
                return NotFound();
            }

            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<ActionResult<EventsDto>> AddEvent([FromBody] CreateEventDto createEventDto)
        {
            // Yeni etkinliği ekle
            await _eventRepository.AddEventAsync(createEventDto);

            // Yeni etkinliği almak için `GetEventById` metodunu çağırarak `EventsDto` döner
            // `GetAllEventsAsync` metodu `List<EventsDto>` döndürüyor, son etkinliği almak için biraz daha karmaşık hale gelir
            // En son etkinliği alıyoruz
            var allEvents = await _eventRepository.GetAllEventsAsync();
            var createdEventDto = allEvents.LastOrDefault(e => e.Title == createEventDto.Title && e.Subtitle == createEventDto.Subtitle && e.StartDate == createEventDto.StartDate);

            if (createdEventDto == null)
            {
                return BadRequest("Event creation failed.");
            }

            return CreatedAtAction(nameof(GetEventById), new { id = createdEventDto.EventId }, createdEventDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent([FromBody] EventsDto eventsDto)
        {
            if (eventsDto.EventId != eventsDto.EventId)
            {
                return BadRequest();
            }

            try
            {
                await _eventRepository.UpdateEventAsync(eventsDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            try
            {
                await _eventRepository.DeleteEventAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
