﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.AirportManagement.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
    }
}
