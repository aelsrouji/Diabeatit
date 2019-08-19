using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
    }
}
