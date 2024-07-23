namespace EventCore_Api.Dtos.EventDetailsDtos
{
    public class CreateEventDetailsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool IsOnline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
    }
}
