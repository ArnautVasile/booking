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
using System.Security.Principal;
using System.Web.Security;

namespace Booking.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController()
        {
            DataContext tmp = new DataContext();

            _unitOfWork = new UnitOfWork(tmp);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/Admin/Login/Index.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Login(EmployeeManager dtoBarbershop)//da nu cred cai nevoie de posthmm
        {
            var employee = await _unitOfWork.BaseUserEntity.FindByUserName(dtoBarbershop.Username);

            if (employee is null)
            {
                // sai faca redirect
            }
            else if (employee.Password == dtoBarbershop.Password)
            {
                UserRole role;

                if (employee.IsAdmin)
                    role = UserRole.Administrator;
                else
                    role = UserRole.Employee;


                // Create session cookie
                HttpCookie userCookie = new HttpCookie("UserSession");
                userCookie["UserId"] = employee.Id.ToString();
                userCookie["UserRole"] = role.ToString();
                userCookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.Cookies.Add(userCookie);

                // Redirect to home page or specific page based on user role
                if (role == UserRole.Administrator)
                    return RedirectToAction("Index", "Home");
                else if (role == UserRole.Employee)
                    return RedirectToAction("Index", "Home");

            }
            /*
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
            */
            return (Index());
        }

        [HttpPost]
        public ActionResult SignOut()//da nu cred cai nevoie de posthmm
        {
            // Clear user session cookie
            HttpCookie userCookie = new HttpCookie("UserSession");
            userCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Response.Cookies.Add(userCookie);

            // Redirect to login page
            return (Index());
        }
    }
}