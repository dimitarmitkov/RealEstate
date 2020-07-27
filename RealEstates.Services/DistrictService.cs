using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private RealEstateDbContext db;

        public DistrictService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictByAveragePrice(int count = 10)
        {
            return db.Districts
                .OrderByDescending(x => x.Properties.Average(y => (double)y.Price / y.Size))
                .Select(MapToDistrictViewModel())
                .Take(count)
                .ToList();
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictByNumberOfProperties(int count = 10)
        {
            return db.Districts
                .OrderByDescending(x => x.Properties.Count())
                .Select(MapToDistrictViewModel())
                .Take(count)
                .ToList();

        }

        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return d => new DistrictViewModel
            {
                AveragePrice = d.Properties.Average(y => (double)y.Price / y.Size),
                MinPrice = d.Properties.Min(y => y.Price),
                MaxPrice = d.Properties.Max(y => y.Price),
                Name = d.Name,
                PropertiesCount = d.Properties.Count(),
            };
        }
    }
}
