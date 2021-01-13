using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class Park : BaseModel
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string WebsiteLink { get; set; }
        public string ParkMapLink { get; set; }
        public List<Ride> Rides { get; set; }
        public List<Visit> Visits { get; set; }
    }
}
