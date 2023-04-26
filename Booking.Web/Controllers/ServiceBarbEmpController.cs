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
    public class ServiceBarbEmpController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // GET: Employee
        public ServiceBarbEmpController()
        {
            DataContext tmp = new DataContext();

            _unitOfWork = new UnitOfWork(tmp);
        }

        public async Task<ActionResult> Index()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAll();
            var services = await _unitOfWork.ServiceRepository.GetAll();
            var barbershops = await _unitOfWork.BarbershopRepository.GetAll();


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
                BarbershopId = e.BarbershopId
            }).ToList();
           
            var servicesManager = services.Select(e => new ServiceManager
            {
                Id = e.Id,
                ServiceName = e.Name,
                ServiceType = e.ServiceType
            }).ToList();

            ServiceBarbEmp ServBarbEmp = new ServiceBarbEmp();

            ServBarbEmp.employees = employeeManager;
            ServBarbEmp.barbershops = barbershopsManager;
            ServBarbEmp.services = servicesManager;


            var serializer = new JavaScriptSerializer();
            var modelJson = serializer.Serialize(ServBarbEmp);
            ViewBag.ModelJson = modelJson;
            return View("~/Views/Admin/Service/Index.cshtml", ServBarbEmp);
        }

        [HttpPost]
        public Task<ActionResult> AddService(ServiceManager dtoService)
        {
            var service = new Service
            {
                Id = Guid.NewGuid(),
                ServiceType = dtoService.ServiceType,
                Name = dtoService.ServiceName
            };

            _unitOfWork.ServiceRepository.Add(service);
            _unitOfWork.BarbershopRepository.AddService(dtoService.BarbershopId, service);
            _unitOfWork.Save();

            return (Index());
        }
    }
}