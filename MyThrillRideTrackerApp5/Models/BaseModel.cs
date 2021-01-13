using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerApp5.Models
{
	public class BaseModel
	{
		[NotMapped]
		public IFormFile ImageFile { get; set; }
		public List<ImageFileName> ImageFiles { get; set; }
	}
}
