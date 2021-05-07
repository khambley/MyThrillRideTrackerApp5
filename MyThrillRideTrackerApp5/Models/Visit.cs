using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class Visit : BaseModel
    {
        public int VisitId { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }

        [NotMapped]
        public string? ParkDisplayName { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

        [ScaffoldColumn(false)]
		public string UserId { get; set; }

		public List<VisitRide> VisitRides { get; set; }

        [Display(Name = "Rating")]
        public int? VisitRating { get; set; }

        [Display(Name = "Comments")]
        public string? VisitComments { get; set; }
    }
}
