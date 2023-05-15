using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
	public class Flight
	{
		[Required(ErrorMessage ="departure obligatoire")]
		public string Departure { get; set; }
		[Required(ErrorMessage = "destination obligatoire")]
		public string Destination { get; set; }
		public DateTime EffectiveArrival { get; set; }
		public float EstimatedDuration { get; set; }
		public DateTime FlightDate { get; set; }
		public int FlightId { get; set; }
		public virtual Plane Plane { get; set; }
		[ForeignKey(nameof(Plane))]
		public int? PlaneId { get; set; }

		public virtual IList<Ticket> Tickets { get; set; }

		public override string ToString()
		{
			return $"FlightId : {FlightId}, Destination : {Destination}, FlightDate : {FlightDate}";
		}
	}
}
