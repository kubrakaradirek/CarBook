using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //SELECT TOP 1 b.Title AS TitleFROM Blogs b INNER JOIN Comments c ON b.BlogId = c.BlogId GROUP BY b.Title ORDER BY COUNT(*) DESC;

            var blogTitle = _context.Blogs
                .Join(_context.Comments, b => b.BlogId, c => c.BlogId, (b, c) => new { Blog = b, Comment = c })
                .GroupBy(x=>x.Blog.Title)
                .OrderByDescending(g=>g.Count())
                .Select(x=>x.Key)
                .FirstOrDefault();
            return blogTitle;
        }

        public string GetBrandNameByMaxCar()
        {
            //SELECT TOP 1 b.Name AS BrandName FROM Cars c INNER JOIN Brands b ON c.BrandId = b.BrandId GROUP BY b.Name ORDER BY COUNT(*) DESC;

            var brandName = _context.Cars
                      .Join(_context.Brands, c => c.BrandId, b => b.BrandId, (c, b) => new { Car = c, Brand = b })
                      .GroupBy(x => x.Brand.Name)
                      .OrderByDescending(g => g.Count())
                      .Select(g => g.Key)
                      .FirstOrDefault();
            return brandName;
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //SELECT AVG(Amount) FROM CarPricings WHERE PricingId=(SELECT PricingId FROM Pricings WHERE Name='Gün')
            int id = _context.Pricings.Where(y => y.Name == "Gün").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Ay").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Hafta").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings Where Amount=(Select MAX(Amount) From CarPricings where PricingId=3)
            // Getting the PricingId for "Gün"
            int pricingId = _context.Pricings
                .Where(x => x.Name == "Gün")
                .Select(p => p.PricingId)
                .FirstOrDefault();

            // Finding the CarId with the maximum amount for the given PricingId
            int carId = _context.CarPricings
                .Where(cp => cp.PricingId == pricingId)
                .OrderByDescending(o => o.Amount)
                .Select(y => y.CarId)
                .FirstOrDefault();

            // Getting the BrandId associated with the CarId
            int brandId = _context.Cars
                .Where(x => x.CarId == carId)
                .Select(y => y.BrandId)
                .FirstOrDefault();

            // Getting the BrandName using the BrandId
            string brandName = _context.Brands
                .Where(x => x.BrandId == brandId)
                .Select(y => y.Name)
                .FirstOrDefault();

            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings
                .Where(x => x.Name == "Gün")
                .Select(p => p.PricingId)
                .FirstOrDefault();

            int carId = _context.CarPricings
                .Where(cp => cp.PricingId == pricingId)
                .OrderBy(o => o.Amount)//(minimum first)
                .Select(y => y.CarId)
                .FirstOrDefault();

            int brandId = _context.Cars
                .Where(x => x.CarId == carId)
                .Select(y => y.BrandId)
                .FirstOrDefault();

            string brandName = _context.Brands
                .Where(x => x.BrandId == brandId)
                .Select(y => y.Name)
                .FirstOrDefault();

            return brandName;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
