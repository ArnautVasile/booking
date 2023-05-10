using Booking.BusinessLogic.Repository;
using Booking.Domain.Entities;
using Booking.Persistance.Context;
using Booking.Persistance.Repository;
using Booking.Web.Models;
using Booking.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Booking.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController()
        {
            DataContext tmp = new DataContext();

            _unitOfWork = new UnitOfWork(tmp);
        }

        public async Task<ActionResult> Index()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAll();
            var services = await _unitOfWork.ServiceRepository.GetAll();
            var barbershops = await _unitOfWork.BarbershopRepository.GetAll();
            var userAppointments = await _unitOfWork.UserAppointmentRepository.GetAll();

            var barbershopsManager = barbershops.Select(b => new BarbershopManager
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                Services = new List<Service>(b.Services),
                Employees = new List<Employee>(b.Employees)
            }).ToList();

            var employeeManager = employees.Select(e => new EmployeeManager
            {
                Id = e.Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Username = e.Username,
                Password = e.Password,
                BarbershopId = e.BarbershopId,
                Services = new List<Service>(e.Services)
            }).ToList();

            var servicesManager = services.Select(e => new ServiceManager
            {
                Id = e.Id,
                ServiceName = e.ServiceName,
                ServiceType = e.ServiceType
            }).ToList();

            var appointmentManager = userAppointments.Select(a => new AppointmentManager
            {
                Id = a.Id,
                LastName = a.LastName,
                FirstName = a.FirstName,
                Phone = a.Phone,
                BarbershopId = a.BarbershopId,
                ServiceId = a.ServiceId,
                EmploeeId = a.EmploeeId,
                Date = a.Date,
                Time = a.Time,
                SetByEmployee = a.SetByEmployee
            }).ToList();

            AppointmentBooking appointmentBooking = new AppointmentBooking();

            appointmentBooking.employees = employeeManager;
            appointmentBooking.barbershops = barbershopsManager;
            appointmentBooking.services = servicesManager;
            appointmentBooking.appointments = appointmentManager; 

            var serializer = new JavaScriptSerializer();
            var modelJson = serializer.Serialize(appointmentBooking);
            ViewBag.ModelJson = modelJson;
            return View("~/Views/Booking/Index.cshtml", appointmentBooking);
        }

        [HttpPost]
        public Task<ActionResult> AddAppointment(AppointmentManager dtoAppointment)
        {
            var userAppointment = new UserAppointment
            {
                Id = Guid.NewGuid(),
                LastName = dtoAppointment.LastName,
                FirstName = dtoAppointment.FirstName,
                Phone = dtoAppointment.Phone,
                BarbershopId = dtoAppointment.BarbershopId,
                ServiceId = dtoAppointment.ServiceId,
                EmploeeId = dtoAppointment.EmploeeId,
            };

            _unitOfWork.UserAppointmentRepository.Add(userAppointment);
            _unitOfWork.Save();

            return (Index());
        }
    }
}