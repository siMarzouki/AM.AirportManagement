using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.AirportManagement.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }
        public override string PassengerType { get { return "Staff passenger type"; } }
        public override string ToString()
        {
            return base.ToString() + $" -- Function : {Function}";
        }
    }
}
