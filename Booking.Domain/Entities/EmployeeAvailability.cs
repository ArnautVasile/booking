using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class EmployeeAvailability
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool SetByEmployee { get; set; }
    }
}
