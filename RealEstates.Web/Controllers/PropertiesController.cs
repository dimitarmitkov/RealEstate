using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstates.Services;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var properties = this.propertyService.SearchByPrice(minPrice, maxPrice);
            return this.View(properties);
        }

        public IActionResult SearchByYear()
        {
            return this.View();
        }

        public IActionResult DoSearchYear(int minYear, int maxYear, int minSize, int maxSize)
        {
            var properyYear = this.propertyService.Search(minYear, maxYear, minSize, maxSize);
            return this.View(properyYear);
        }
    }
}
