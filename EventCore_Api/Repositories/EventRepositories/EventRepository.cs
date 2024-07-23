using EventCore_Api.Dtos.EventsDtos;
using EventCore_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCore_Api.Repositories.EventRepositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EventsDto>> GetAllEventsAsync()
        {
            // Events modelini EventsDto'ya dönüştür ve List döndür
            return await _context.Events
                .Select(e => new EventsDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Subtitle = e.Subtitle,
                    StartDate = e.StartDate
                })
                .ToListAsync();
        }

        public async Task<EventsDto> GetEventByIdAsync(int id)
        {
            // Events modelini EventsDto'ya dönüştür
            var eventEntity = await _context.Events
                .Where(e => e.EventId == id)
                .Select(e => new EventsDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Subtitle = e.Subtitle,
                    StartDate = e.StartDate
                })
                .FirstOrDefaultAsync();

            return eventEntity;
        }

        public async Task AddEventAsync(CreateEventDto createEventDto)
        {
            var newEvent = new Events
            {
                Title = createEventDto.Title,
                Subtitle = createEventDto.Subtitle,
                StartDate = createEventDto.StartDate
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(EventsDto eventsDto)
        {
            var eventEntity = await _context.Events.FindAsync(eventsDto.EventId);
            if (eventEntity != null)
            {
                eventEntity.Title = eventsDto.Title;
                eventEntity.Subtitle = eventsDto.Subtitle;
                eventEntity.StartDate = eventsDto.StartDate;

                _context.Entry(eventEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity != null)
            {
                _context.Events.Remove(eventEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
