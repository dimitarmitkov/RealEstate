using System.Collections.Generic;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertyService
    {
        void Create(string districtName, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors);

        void UpdateTags(int proppertyId);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}
