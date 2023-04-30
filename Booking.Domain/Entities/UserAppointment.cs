using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class UserAppointment
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool SetByEmployee { get; set; }
        public Guid BarbershopId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid EmploeeId { get; set; }
    }
}
