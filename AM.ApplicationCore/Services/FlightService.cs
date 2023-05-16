using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
	public class FlightService :Service<Flight>, IFlightService 
	{
		ICollection<Flight> source;
		ShowLine showLine;

		public FlightService(ICollection<Flight> source,ShowLine showLine ) : base(null)
		{
			this.source = source;	
			this.showLine = showLine;	
			
		}
		public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		public void ShowFlights(string filterType, string filterValue)
		{
			showLine($"=== Filter type : {filterType}, Filter value : {filterValue} ===");
			switch (filterType)
			{
				case "Destination":
					foreach (Flight flight in source) 
					{
						if(flight.Destination == filterValue)
						{
							showLine(flight);
						}
					}
					break;
				case "FlightDate":
					DateTime d = DateTime.Parse(filterValue);
					foreach (Flight flight in source)
					{
						if (flight.FlightDate == d)
						{
							showLine(flight);
						}
					}
					break;
				case "FlightId":
					int id = int.Parse(filterValue);
					foreach (Flight flight in source)
					{
						if (flight.FlightId == id)
						{
							showLine(flight);
						}
					}
					break;
				default:
					throw new Exception("Unknow Filter");
			}
		}

		public  IEnumerable<Object> GetDurationInMinutes()
		{
			return source.Select(e => new { e.FlightId, EstimatedDurationInMinnutes = 60 * e.EstimatedDuration });
		}
		public IEnumerable<Flight> GetFlightSortedByDuration()
		{
			return source.OrderByDescending(e => e.EstimatedDuration);
		}
		public float GetDurationAverage()
		{
			return source.Average(e => e.EstimatedDuration);
		}
		
		public IEnumerable<Object> GetDurationInMinutesLINQ()
		{
			return from e in source select new { e.FlightId, EstimatedDurationInMinutes = e.EstimatedDuration * 60 };
		}

		public IEnumerable<Flight> GetFlightsByDestination(string destination)
		{
			return GetMany(e => e.Destination == destination);
		}
	}
}
