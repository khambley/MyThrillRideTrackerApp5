using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class VisitRide : BaseModel
	{
		public int VisitRideId { get; set; }
		public int VisitId { get; set; }
		public Visit Visit { get; set; }
		public int RideId { get; set; }
		public Ride Ride { get; set; }

		[ScaffoldColumn(false)]
		public string UserId { get; set; }

		[Display(Name = "Rating")]
		public int? VisitRideRating { get; set; }
		[Display(Name = "Comments")]
		public string? VisitRideComments { get; set; }

	}
}
