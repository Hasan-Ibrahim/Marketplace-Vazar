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

        
    }
}