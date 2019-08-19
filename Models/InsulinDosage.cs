using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class InsulinDosage
    {
        public long DosageId { get; set; }
        public long UserId { get; set; }
        public int BloodSugarRangeId { get; set; }
        public float InsulinDosage1 { get; set; }
    }
}
