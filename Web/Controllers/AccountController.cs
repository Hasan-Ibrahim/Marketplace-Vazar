using System.Web.Mvc;
using System.Web.Security;
using Service.Account;
using Login = Web.Models.Account.Login;

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
            var valid = _accountService.ValidateUser(login.LoginId, login.Password);

            if (valid)
            {
                FormsAuthentication.SetAuthCookie(login.LoginId, login.RememberMe);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}