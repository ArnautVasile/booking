using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Booking.Domain.Entities;

namespace Booking.Web.Models
{
    public class BarbershopManager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Service> Services { get; set; }
        public List<Employee> Employees { get; set; }
    }
}