using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking.Web.Models;
using Booking.BusinessLogic.Repository;
using Booking.Persistance.Repository;
using Booking.Persistance.Context;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Web.Controllers
{
    public class BarbershopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BarbershopController()
        {
            DataContext tmp = new DataContext();

            _unitOfWork = new UnitOfWork(tmp);
        }

        public async Task<ActionResult> Index()
        {
            var barbershop = await _unitOfWork.BarbershopRepository.GetAll();

            var barbershopManagers = barbershop.Select(e => new BarbershopManager
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                Services = e.Services,
                Employees = e.Employees,
            }).ToList();
            return View("~/Views/Admin/Barbershop/Index.cshtml", barbershopManagers);
        }

        [HttpPost]
        public Task<ActionResult> AddBarbershop(BarbershopManager dtoBarbershop)
        {
            var barbershop = new Barbershop
            {
                Id = Guid.NewGuid(),
                Name = dtoBarbershop.Name,
                Address = dtoBarbershop.Address,
                Services = new List<Service>(),
                Employees = new List<Employee>()
            };
            
            _unitOfWork.BarbershopRepository.Add(barbershop);
            _unitOfWork.Save();
            return (Index());
        }

        [HttpPost]
        public Task<ActionResult> UpdateBarbershop(Barbershop dtoEmployee)
        {
            var barbershop = new Barbershop
            {
                Id = dtoEmployee.Id,
                Name = dtoEmployee.Name,
                Address = dtoEmployee.Address
            };

            _unitOfWork.BarbershopRepository.Update(barbershop);
            _unitOfWork.Save();
            return (Index());
        }

        [HttpPost]
        public Task<ActionResult> DeleteBarbershop(BarbershopManager dtoEmployee)
        {
            var barbershop = new Barbershop
            {
                Id = dtoEmployee.Id,
                Name = dtoEmployee.Name,
                Address = dtoEmployee.Address
            };

            _unitOfWork.BarbershopRepository.Delete(barbershop);
            _unitOfWork.Save();

            return (Index());
        }
    }
}