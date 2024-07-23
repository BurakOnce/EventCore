using EventCore_Api.Dtos.EventDetailsDtos;
using EventCore_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCore_Api.Repositories.EventDetailsRepositories
{
    public class EventDetailsRepository : IEventDetailsRepository
    {
        private readonly DataContext _context;

        public EventDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EventDetailsDto>> GetAllEventDetailsAsync()
        {
            // EventDetails modelini EventDetailsDto'ya dönüştür ve List döndür
            return await _context.EventDetails
                .Select(ed => new EventDetailsDto
                {
                    EventDetailId = ed.EventDetailId,
                    Title = ed.Title,
                    Description = ed.Description,
                    Speakers = ed.Speakers,
                    Location = ed.Location,
                    Capacity = ed.Capacity,
                    IsOnline = ed.IsOnline,
                    StartDate = ed.StartDate,
                    EndDate = ed.EndDate,
                    EventId = ed.EventId
                })
                .ToListAsync();
        }

        public async Task<EventDetailsDto> GetEventDetailByIdAsync(int id)
        {
            // EventDetails modelini EventDetailsDto'ya dönüştür
            var eventDetailEntity = await _context.EventDetails
                .Where(ed => ed.EventId == id)
                .Select(ed => new EventDetailsDto
                {
                    EventDetailId = ed.EventDetailId,
                    Title = ed.Title,
                    Description = ed.Description,
                    Speakers = ed.Speakers,
                    Location = ed.Location,
                    Capacity = ed.Capacity,
                    IsOnline = ed.IsOnline,
                    StartDate = ed.StartDate,
                    EndDate = ed.EndDate,
                    EventId = ed.EventId
                })
                .FirstOrDefaultAsync();

            return eventDetailEntity;
        }

        public async Task AddEventDetailAsync(CreateEventDetailsDto createEventDetailsDto)
        {
            var newEventDetail = new EventDetails
            {
                Title = createEventDetailsDto.Title,
                Description = createEventDetailsDto.Description,
                Speakers = createEventDetailsDto.Speakers,
                Location = createEventDetailsDto.Location,
                Capacity = createEventDetailsDto.Capacity,
                IsOnline = createEventDetailsDto.IsOnline,
                StartDate = createEventDetailsDto.StartDate,
                EndDate = createEventDetailsDto.EndDate,
                EventId = createEventDetailsDto.EventId
            };

            _context.EventDetails.Add(newEventDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventDetailAsync(EventDetailsDto eventDetailsDto)
        {
            var eventDetailEntity = await _context.EventDetails.FindAsync(eventDetailsDto.EventDetailId);
            if (eventDetailEntity != null)
            {
                eventDetailEntity.Title = eventDetailsDto.Title;
                eventDetailEntity.Description = eventDetailsDto.Description;
                eventDetailEntity.Speakers = eventDetailsDto.Speakers;
                eventDetailEntity.Location = eventDetailsDto.Location;
                eventDetailEntity.Capacity = eventDetailsDto.Capacity;
                eventDetailEntity.IsOnline = eventDetailsDto.IsOnline;
                eventDetailEntity.StartDate = eventDetailsDto.StartDate;
                eventDetailEntity.EndDate = eventDetailsDto.EndDate;
                eventDetailEntity.EventId = eventDetailsDto.EventId;

                _context.Entry(eventDetailEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEventDetailAsync(int id)
        {
            var eventDetailEntity = await _context.EventDetails.FindAsync(id);
            if (eventDetailEntity != null)
            {
                _context.EventDetails.Remove(eventDetailEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
