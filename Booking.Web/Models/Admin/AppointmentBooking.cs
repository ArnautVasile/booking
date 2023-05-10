using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Web.Models.Admin
{
    public class AppointmentBooking
    {
        public List<EmployeeManager> employees;
        public List<BarbershopManager> barbershops;
        public List<ServiceManager> services;
        public List<AppointmentManager> appointments;
    }
}