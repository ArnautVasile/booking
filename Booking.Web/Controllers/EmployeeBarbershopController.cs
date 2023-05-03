using Booking.BusinessLogic.Repository;
using Booking.Domain.Entities;
using Booking.Persistance.Context;
using Booking.Persistance.Repository;
using Booking.Web.Models.Admin;
using Booking.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Booking.Web.Filters;
using Booking.BusinessLogic.Enums;

namespace Booking.Web.Controllers
{
   // [AccessLevel(UserRole.Employee)]
    public class EmployeeBarbershopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // GET: Employee
        public EmployeeBarbershopController()
        {
            DataContext tmp = new DataContext();

            _unitOfWork = new UnitOfWork(tmp);
        }

        public async Task<ActionResult> Index()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAll();
            var barbershops = await _unitOfWork.BarbershopRepository.GetAll();

            var employeeManagers = employees.Select(e => new EmployeeManager
            {
                Id = e.Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Username = e.Username,
                Password = e.Password,
                BarbershopId = e.BarbershopId
            }).ToList();

            var barbershopsManagers = barbershops.Select(e => new BarbershopManager
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                Services = e.Services,
                Employees = e.Employees
            }).ToList();

            EmployeeBarbershop employeeBarbershop = new EmployeeBarbershop();

            employeeBarbershop.employees = employeeManagers;
            employeeBarbershop.barbershops = barbershopsManagers;

            return View("~/Views/Admin/Employee/Index.cshtml", employeeBarbershop);
        }

        [HttpPost]
        public Task<ActionResult> AddEmployee(EmployeeManager dtoEmployee)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                LastName = dtoEmployee.LastName,
                FirstName = dtoEmployee.FirstName,
                Username = dtoEmployee.Username,
                Password = dtoEmployee.Password,
                BarbershopId = dtoEmployee.BarbershopId,
                Services = new List<Service>()
            };

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.BarbershopRepository.AddEmployee(employee.BarbershopId, employee);
            _unitOfWork.Save();

            return (Index());
        }


        [HttpPost]
        public async Task<ActionResult> UpdateEmployee(EmployeeManager dtoEmployee)
        {
            var savedEmployee = await _unitOfWork.EmployeeRepository.GetById(dtoEmployee.Id);

            if (savedEmployee.BarbershopId != dtoEmployee.BarbershopId)
            {
                await _unitOfWork.BarbershopRepository.RmEmployee(savedEmployee.BarbershopId, savedEmployee);
                _unitOfWork.BarbershopRepository.AddEmployee(dtoEmployee.BarbershopId, savedEmployee);
            }

            savedEmployee.LastName = dtoEmployee.LastName;
            savedEmployee.FirstName = dtoEmployee.FirstName;
            savedEmployee.Username = dtoEmployee.Username;
            savedEmployee.Password = dtoEmployee.Password;
            savedEmployee.BarbershopId = dtoEmployee.BarbershopId;

            _unitOfWork.EmployeeRepository.Update(savedEmployee);
            _unitOfWork.Save();

            return (await Index());
        }

        [HttpPost]
        public Task<ActionResult> DeleteEmployee(EmployeeManager dtoEmployee)
        {
            _unitOfWork.EmployeeRepository.Delete(dtoEmployee.Id);
            _unitOfWork.Save();

            return (Index());
        }
    }
}