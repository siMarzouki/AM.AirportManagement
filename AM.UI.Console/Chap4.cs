using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

namespace AM.UI.Console
{
	public class Chap4
	{
		public static void Test1()
		{
			using (var unitOfWork  = new UnitOfWork())
			{
				unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing1);
				unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing2);
				unitOfWork.Commit();
				unitOfWork.Repository<Plane>().Add(InMemorySource.Airbus);
			}
		}

		public static void Test2()
		{
			using(var unitOfWork = new UnitOfWork())
			{
				ShowLine showLine = System.Console.WriteLine;

				new FlightService(unitOfWork).GetFlightsByDestination("Paris").ShowList("flights : ",System.Console.WriteLine);
				var planeService = new PlaneService(unitOfWork);

				planeService.GetOldPlanes().ShowList("== GetOldPlanes ==", showLine);
				planeService.GetFlights(200).ShowList("== GetFlights ==", showLine);


				//new TicketService(unitOfWork).GetVIPTravellers().ShowList("vip : ", showLine);
			}
		}
	}
}
