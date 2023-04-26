using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Web.Models
{
    public class ServiceManager
    {
        public Guid Id { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public Guid BarbershopId { get; set; }
    }
}