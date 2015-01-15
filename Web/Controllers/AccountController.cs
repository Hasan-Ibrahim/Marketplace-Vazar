using System.Web.Mvc;
using System.Web.Security;
using Service.Account;
using Login = Service.Account.Login;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            var loggedIn = false;
            var valid = _accountService.ValidateUser(login.LoginId, login.Password);

            if (valid)
            {
                FormsAuthentication.SetAuthCookie(login.LoginId, login.RememberMe);
                loggedIn = true;
            }

            return Json(new { success = loggedIn });
        }

        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            var created = false;
            if (ModelState.IsValid)
            {
                created = _accountService.CreateUser(registration.Email, registration.Password);
            }
            return Json(new { registered = created });
        }

        [HttpPost]
        public ActionResult Update(ProfileUpdate update)
        {
            var updated = false;
            if (ModelState.IsValid)
            {
                updated = _accountService.UpdateProfile(User.Identity.Name, update);
                if (updated)
                {
                    ViewBag.FullName = update.FullName;
                }
            }

            return RedirectToAction("Index", "Home", new { updated = updated });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}