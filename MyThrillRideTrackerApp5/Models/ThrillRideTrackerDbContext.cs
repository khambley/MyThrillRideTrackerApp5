using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class ThrillRideTrackerDbContext : DbContext
	{
		public ThrillRideTrackerDbContext (DbContextOptions<ThrillRideTrackerDbContext> options)
			: base(options) { }

		public DbSet<Park> Parks { get; set; }
		public DbSet<Ride> Rides { get; set; }
		public DbSet<Visit> Visits { get; set; }
		public DbSet<VisitRide> VisitRides { get; set; }
		public DbSet<ImageFileName> ImageFileNames { get; set; }
	}
}
