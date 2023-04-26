using System;

namespace Booking.Web.Models
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