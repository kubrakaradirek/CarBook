using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7284/api/Locations");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                    if (values != null)
                    {
                        List<SelectListItem> values2 = (from x in values
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.LocationId.ToString()
                                                        }).ToList();
                        ViewBag.v = values2;
                    }
                    else
                    {
                        // Handle the case where values are null
                        ViewBag.v = new List<SelectListItem>();
                    }
                }
                else
                {
                    // Handle the case where the response was not successful
                    ViewBag.v = new List<SelectListItem>();
                }
            }
            else
            {
                // Handle the case where the token is null
                ViewBag.v = new List<SelectListItem>();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(string book_pick_date,string book_off_date,string time_pick,string time_off,string locationId)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_pick_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationId"] = locationId;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
