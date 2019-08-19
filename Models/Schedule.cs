using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class Schedule
    {
        public long ScheduleId { get; set; }
        public long UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool Active { get; set; }
    }
}
