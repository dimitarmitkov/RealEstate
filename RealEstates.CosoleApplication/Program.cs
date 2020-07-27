using System;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.CosoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDbContext();

            db.Database.Migrate();

            IPropertyService propertyService = new PropertyService(db);

            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            var properties = propertyService.SearchByPrice(minPrice, maxPrice);


            IDistrictService districtService = new DistrictService(db);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District}, fl. {property.Floor}, {property.Size} m², {property.Year}, {property.Price}€, {property.PropertyType}, {property.BuildingType}");
            }

            var districts = districtService.GetTopDistrictByNumberOfProperties();


            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => Price: {district.AveragePrice:0.00} ({district.MinPrice}-{district.MaxPrice}) => {district.PropertiesCount} properties");
            }

        }
    }
}
