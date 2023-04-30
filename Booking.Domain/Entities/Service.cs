using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
    }
}
