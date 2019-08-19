using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public DateTime? LastActivity { get; set; }
        public int? DiabetesType { get; set; }
        public DateTime FirstDiagnosed { get; set; }
        public bool Sex { get; set; }
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public int? MedicineId { get; set; }
    }
}
