using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Rezervasyon";
            ViewBag.v2 = "Rezervasyon Formu";
            ViewBag.v3 = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7284/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> locations = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.LocationId.ToString()
                                                  }).ToList();
                ViewBag.Locations = locations;

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponseMessage = await client.PostAsync("https://localhost:7284/api/ReservationS", content);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
