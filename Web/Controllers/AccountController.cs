using System.Web.Mvc;
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

            return RedirectToAction("Index", "Home");
        }
    }
}