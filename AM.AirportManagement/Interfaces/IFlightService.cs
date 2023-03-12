using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.AirportManagement.Interfaces
{
    public interface IFlightService
    {
        void ShowFlights(string filterType, string filterValue);
    }
}
