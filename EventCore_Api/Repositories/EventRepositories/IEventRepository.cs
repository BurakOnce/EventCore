using EventCore_Api.Dtos.EventsDtos;
using EventCore_Api.Models;

namespace EventCore_Api.Repositories.EventRepositories
{
    public interface IEventRepository
    {
        Task<List<EventsDto>> GetAllEventsAsync(); 
        Task<EventsDto> GetEventByIdAsync(int id);
        Task AddEventAsync(CreateEventDto createEventDto);
        Task UpdateEventAsync(EventsDto eventsDto); 
        Task DeleteEventAsync(int id);
    }
}
