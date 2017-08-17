
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using blog1.Models;
namespace blog1.Controllers
{
    public class UserController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;
                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string displayedName = user.DisplayName;
                    ViewData.Add("DisplayName", displayedName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public UserController()
        { }
    }
}
