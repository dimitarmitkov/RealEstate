using System.Collections.Generic;

namespace RealEstates.Services
{
    public interface IDistrictService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictByAveragePrice(int count = 10);

        IEnumerable<DistrictViewModel> GetTopDistrictByNumberOfProperties(int count = 10);
    }
}
