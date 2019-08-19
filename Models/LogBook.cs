using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class LogBook
    {
        public long LogBookId { get; set; }
        public long UserId { get; set; }
        public DateTime LogDate { get; set; }
        public TimeSpan LogTime { get; set; }
        public float MeterReading { get; set; }
        public string LogNotes { get; set; }
        public long RoutineId { get; set; }
    }
}
