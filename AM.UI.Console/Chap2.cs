using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore;
using AM.ApplicationCore.Services;
namespace AM.UI.Console
{
	public class Chap2
	{
		static ShowLine showLine = System.Console.WriteLine;

		public static void Test1() 
		{
			var flightService = new FlightService(InMemorySource.Flights, showLine);
			flightService.ShowFlights("Destination", "Paris");
			flightService.ShowFlights("Destination", "Madrid");
			flightService.ShowFlights("FlightId", "3");
		}
		public static void Test2()
		{
			var flightService = new FlightService(InMemorySource.Flights, showLine);

			flightService.GetDurationInMinutes().ShowList("== GetDurationsInMinutes ==", showLine);
			flightService.GetFlightSortedByDuration().ShowList("== GetFlightsSortedByDuration ==", showLine);
			new[] { flightService.GetDurationAverage() }.ShowList("== GetDurationsAverage ==", showLine);
			flightService.GetDurationInMinutesLINQ().ShowList("== GetDurationsInMinutesLINQ ==", showLine);
		}
	}
}
