using EventCore_UI.Dtos.EventsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventCore_UI.ViewComponents.HomePage
{
    public class _DefaultScheduleComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultScheduleComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7189/api/Event");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<EventsDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
