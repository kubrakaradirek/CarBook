using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region-TotalCarCountStatistic
            var responseMessage = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = v1;
            }
            #endregion

            #region-TotalLocationCountStatistic
            var responseMessage2 = await client.GetAsync("https://localhost:7284/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region-TotalAuthorCountStatistic
            var responseMessage3 = await client.GetAsync("https://localhost:7284/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int authorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.authorCount = values3.AuthorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region-TotalBlogCountStatistic
            var responseMessage4 = await client.GetAsync("https://localhost:7284/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.blogCount = values4.BlogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            #endregion

            #region-TotalBrandCountStatistic
            var responseMessage5 = await client.GetAsync("https://localhost:7284/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCount = values5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region-AvgRentPriceForDailyStatistic
            var responseMessage6 = await client.GetAsync("https://localhost:7284/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = values6.avgPriceForDaily.ToString("0.00"); ;
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            #endregion

            #region-AvgRentPriceForWeeklyStatistic
            var responseMessage7 = await client.GetAsync("https://localhost:7284/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.avgPriceForWeekly.ToString("0.00"); ;
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion

            #region-AvgPriceForMonthlyStatistic
            var responseMessage8 = await client.GetAsync("https://localhost:7284/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgPriceForMonthlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.avgPriceForMonthly = values8.avgPriceForMonthly.ToString("0.00"); ;
                ViewBag.avgPriceForMonthlyRandom = avgPriceForMonthlyRandom;
            }
            #endregion

            #region-CarCountByTransmissionIsAutoStatistic
            var responseMessage9 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTransmissionIsAutoRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAuto = values9.carCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
            }
            #endregion

            #region-CarCountByKmSmallerThen1000Statistic
            var responseMessage10 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int carCountByKmSmallerThen1000Random = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10= JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);
                ViewBag.carCountByKmSmallerThen1000 = values10.carCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            }
            #endregion

            #region-CarCountByFuelGasolineOrDieselStatistic
            var responseMessage11 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData11);
                ViewBag.carCountByFuelGasolineOrDiesel = values11.carCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            }
            #endregion

            #region-CarCountByFuelGasolineOrDieselStatistic
            var responseMessage12 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData12);
                ViewBag.carCountByFuelElectric = values12.carCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            #endregion

            #region-CarBrandAndModelByRentPriceDailyMaxStatistic
            var responseMessage13 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData13);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values13.carBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            }
            #endregion

            #region-CarBrandAndModelByRentPriceDailyMinStatistic
            var responseMessage14 = await client.GetAsync("https://localhost:7284/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values14.carBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }
            #endregion

            #region-BrandNameByMaxCarStatistic
            var responseMessage15 = await client.GetAsync("https://localhost:7284/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData15);
                ViewBag.brandNameByMaxCar = values15.brandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }
            #endregion

            #region-BlogTitleByMaxBlogCommentStatistic
            var responseMessage16 = await client.GetAsync("https://localhost:7284/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData16);
                ViewBag.blogTitleByMaxBlogComment = values16.blogTitleByMaxBlogComment;
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            }
            #endregion

            return View();
        }
    }
}
