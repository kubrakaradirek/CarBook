﻿using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Location")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
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
                    return View(values);
                }
            }
            return View();
        }

        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7284/api/Locations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7284/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7284/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7284/api/Locations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }
    }
}
