using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class ImageFileName
	{
        public int ImageFileNameId { get; set; }
        public string FileName { get; set; }

        public int? ParkId { get; set; }
        public Park Park { get; set; }

        public int? RideId { get; set; }
        public Ride Ride { get; set; }

        public int? VisitId { get; set; }
        public Visit Visit { get; set; }

        public int? VisitRideId { get; set; }
        public VisitRide VisitRide { get; set; }
    }
}
