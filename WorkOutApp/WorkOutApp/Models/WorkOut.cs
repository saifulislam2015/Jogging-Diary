using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutApp.Models
{
    public class WorkOut
    {

        public int Id { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        public int DistanceInMenters { get; set; }
        [Required]
        public int TimeInSeconds { get; set; }
    }
}
