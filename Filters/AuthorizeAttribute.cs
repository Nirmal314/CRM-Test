using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.WebControls;
using Test.Models;

namespace SITClone.Filters
{
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        private readonly ExamEntities1 _db;

        public AuthorizeAttribute()
        {
            _db = new ExamEntities1();
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            List<string> SRoles = Roles.Split(',').ToList();
            bool isAuthorized = false;

            foreach (var role in SRoles)
            {
                if (IsUserInRole(Convert.ToInt32(filterContext.HttpContext.Session["UserId"]), role))
                {
                    isAuthorized = true;
                }
            }
            if (!isAuthorized)
            {
                filterContext.Controller.ViewBag.Error = "Unauthorized";
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public bool IsUserInRole(int id, string type)
        {
            string department = (from u in _db.Users
                                 where u.UserId == id
                                 select u.Type).FirstOrDefault();

            return department == type;
        }
    }
}