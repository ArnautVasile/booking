using Booking.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Booking.Web.Filters
{
    public class AccessLevelAttribute : ActionFilterAttribute
    {
        private readonly UserRole[] _allowedRoles;

        public AccessLevelAttribute(params UserRole[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies["UserSession"];

            if (cookie == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var identity = new GenericIdentity(cookie["UserId"]);
            var roles = new[] { cookie["UserRole"] };
            var principal = new GenericPrincipal(identity, roles);
            filterContext.HttpContext.User = principal;

            if (!principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (!_allowedRoles.Contains((UserRole)Enum.Parse(typeof(UserRole), cookie["UserRole"])))
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
        /*
        private UserRole GetUserRole(string username)
        {
            // replace this with your own logic to get the user's role
            // based on their username, user ID, or any other criteria
            return UserRole.Employee;
        }
        */
    }
}