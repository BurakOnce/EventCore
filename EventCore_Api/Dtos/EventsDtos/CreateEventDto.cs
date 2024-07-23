namespace EventCore_Api.Dtos.EventsDtos
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime StartDate { get; set; }
    }
}
