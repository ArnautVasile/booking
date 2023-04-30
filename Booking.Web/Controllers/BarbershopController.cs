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
using Booking.BusinessLogic.Enums;

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
            HttpCookie userCookie = Request.Cookies["UserSession"];
            
            if (userCookie != null)
            {
                //asta nu treb acum dar ar trbuui asa sa fie scris   int userId = int.Parse(userCookie.Values["UserId"]);
                Guid userId = new Guid(userCookie.Values["UserId"]);

                UserRole userRole = (UserRole)Enum.Parse(typeof(UserRole), userCookie.Values["UserRole"]);

                // Do something with userId and userRole
            }
            else
            {
                return RedirectToAction("Index", "Login");
                //retuerRedirectToAction("Index", "Login", new { area = "Admin" });
                //return RedirectToAction("Index", "Login", new { area = "Admin", routeName = "AdminLogin" });
            }

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

            _unitOfWork.BarbershopRepository.Delete(barbershop.Id);
            _unitOfWork.Save();

            return (Index());
        }
    }
}