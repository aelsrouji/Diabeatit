using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diabeatit.Models
{
    public partial class LogBook
    {
        [Key, Column(Order = 0)]
        public long LogBookId { get; set; }
        [Key, Column(Order = 1)]
        public long UserId { get; set; }
        [Display(Name ="Date")]
        public DateTime LogDate { get; set; }
        [Display(Name = "Time")]
        public TimeSpan LogTime { get; set; }
        [Display(Name = "Reading")]
        public float MeterReading { get; set; }
        [Display(Name = "Notes")]
        public string LogNotes { get; set; }
        [Display(Name = "Routine")]
        public long RoutineId { get; set; }


    }
}
