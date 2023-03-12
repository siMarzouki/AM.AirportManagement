﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.AirportManagement.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }
        public IList<Flight> Flights { get; set; }
        public virtual string PassengerType { get { return "Unknown passenger type"; } }

        public override string ToString()
        {
            return $"PassportNumber : {PassportNumber}, FirstName : {FirstName}, LastName : {LastName}";
        }
    }
}
