using EventCore_Api.Dtos.EventDetailsDtos;

namespace EventCore_Api.Repositories.EventDetailsRepositories
{
    public interface IEventDetailsRepository
    {
        Task<List<EventDetailsDto>> GetAllEventDetailsAsync();
        Task<EventDetailsDto> GetEventDetailByIdAsync(int id);
        Task AddEventDetailAsync(CreateEventDetailsDto createEventDetailsDto);
        Task UpdateEventDetailAsync(EventDetailsDto eventDetailsDto);
        Task DeleteEventDetailAsync(int id);
    }
}
