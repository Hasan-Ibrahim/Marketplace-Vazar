using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserProfileController : Controller
    {
        [Authorize]
        public ActionResult GetUser()
        {
            return Json(new {user = User.Identity.Name});
        }
	}
}
