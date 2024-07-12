using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;
		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToList();
			return values;
		}

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
			//var carPricings = _context.CarPricings
			//    .Include(cp => cp.Car)
			//    .ThenInclude(c => c.Brand)
			//    .ToList();

			//var pivotedData = carPricings
			//	.GroupBy(cp => new { cp.Car.Brand.Name, cp.Car.Model })
			//	.Select(g => new CarPricingDto
			//	{
			//		Brand_Model = g.Key.Name + " - " + g.Key.Model,
			//		Pricing2 = g.Where(cp => cp.PricingId == 2).Sum(cp => (decimal?)cp.Amount),
			//		Pricing3 = g.Where(cp => cp.PricingId == 3).Sum(cp => (decimal?)cp.Amount),
			//		Pricing4 = g.Where(cp => cp.PricingId == 4).Sum(cp => (decimal?)cp.Amount),
			//		Pricing8 = g.Where(cp => cp.PricingId == 8).Sum(cp => (decimal?)cp.Amount)
			//	})
			//	.ToList();

			//return pivotedData;
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values=new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText= "select*from\r\n\r\n(select Brands.Name +' - '+ model as Brand_Model,PricingId,Amount,CoverImageUrl from CarPricings\r\n\r\ninner join Cars on Cars.CarID=CarPricings.CarID\r\n\r\ninner join  Brands on Brands.BrandID=Cars.BrandID\r\n\r\n)as SourceTable\r\n\r\npivot(sum(Amount) For PricingID In ([2],[3],[4],[8])) as PivotTable;";
				command.CommandType=System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using(var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Model = reader["Brand_Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader[2]),
								Convert.ToDecimal(reader[3]),
								Convert.ToDecimal(reader[4]),
							}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
