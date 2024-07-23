using EventCore_UI.Dtos.EventDetailsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventCore_UI.Controllers
{
    public class EventDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EventSingle(int id)
        {
            id = 6;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7189/api/EventDetails/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EventDetailsDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
