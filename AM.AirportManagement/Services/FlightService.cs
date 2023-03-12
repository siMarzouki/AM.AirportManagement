using AM.AirportManagement.Domain;
using AM.AirportManagement.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.AirportManagement.Services
{
    public class FlightService : IFlightService
    {
        ICollection source;

        public FlightService(ICollection source)
        {
            this.source = source;
        }
        public void ShowFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight item in source)
                    {
                        if (item.Destination == filterValue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightDate":
                    DateTime flightDate = DateTime.Parse(filterValue);

                    foreach (Flight item in source)
                    {
                        if (item.FlightDate == flightDate)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightId":
                    int flightId = int.Parse(filterValue);

                    foreach (Flight item in source)
                    {
                        if (item.FlightId == flightId)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown filter");
            }
        }
    

}
}
