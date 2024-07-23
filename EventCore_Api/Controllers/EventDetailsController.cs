using EventCore_Api.Dtos.EventDetailsDtos;
using EventCore_Api.Repositories.EventDetailsRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EventCore_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailsRepository _eventDetailsRepository;

        public EventDetailsController(IEventDetailsRepository eventDetailsRepository)
        {
            _eventDetailsRepository = eventDetailsRepository;
        }

        // GET: api/EventDetails
        [HttpGet]
        public async Task<ActionResult<List<EventDetailsDto>>> GetAllEventDetails()
        {
            var eventDetails = await _eventDetailsRepository.GetAllEventDetailsAsync();
            return Ok(eventDetails);
        }

        // GET: api/EventDetails/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsDto>> GetEventDetailById(int id)
        {
            var eventDetail = await _eventDetailsRepository.GetEventDetailByIdAsync(id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            return Ok(eventDetail);
        }

        // POST: api/EventDetails
        [HttpPost]
        public async Task<ActionResult> AddEventDetail(CreateEventDetailsDto createEventDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _eventDetailsRepository.AddEventDetailAsync(createEventDetailsDto);

            return CreatedAtAction(nameof(GetEventDetailById), new { id = createEventDetailsDto.EventId }, createEventDetailsDto);
        }

        // PUT: api/EventDetails/{id}
        [HttpPut]
        public async Task<ActionResult> UpdateEventDetail(EventDetailsDto eventDetailsDto)
        {
            if (eventDetailsDto.EventDetailId != eventDetailsDto.EventDetailId)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _eventDetailsRepository.UpdateEventDetailAsync(eventDetailsDto);

            return NoContent();
        }

        // DELETE: api/EventDetails/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventDetail(int id)
        {
            var eventDetail = await _eventDetailsRepository.GetEventDetailByIdAsync(id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            await _eventDetailsRepository.DeleteEventDetailAsync(id);

            return NoContent();
        }
    }
}
