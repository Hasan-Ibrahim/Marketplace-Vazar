using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Account;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService _service;

        public HomeController(AccountService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
