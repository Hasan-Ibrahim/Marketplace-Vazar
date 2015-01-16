using System.Web.Http;
using Api.AccessControl;
using Data.TokenStorages;
using Service.Account;

namespace Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly AccountService _service;
        private readonly ITokenStorage _tokenStorage;
        private readonly TokenUser _tokenUser;

        public AccountController(AccountService service, ITokenStorage tokenStorage, TokenUser tokenUser)
        {
            _service = service;
            _tokenStorage = tokenStorage;
            _tokenUser = tokenUser;
        }

        [HttpPost]
        public string GetToken([FromBody]Login login)
        {
            if (_service.ValidateUser(login))
            {
                return _tokenStorage.CreateToken(login.LoginId);
            }
            return null;
        }

        [HttpPost]
        public object Register([FromBody]Registration registration)
        {
            var created = false;
            if (ModelState.IsValid)
            {
                created = _service.CreateUser(registration.Email, registration.Password);
            }

            return new { Registered = created };
        }

        [HttpPut]
        public object Update([FromBody]ProfileUpdate update)
        {
            var updated = false;
            if (ModelState.IsValid)
            {
                updated = _service.UpdateProfile(_tokenUser.LoginId, update);
            }

            return new { Updated = updated, FullName = update.FullName };
        }

        [HttpGet]
        public bool Logout()
        {
            _tokenStorage.DeleteToken(_tokenUser.LoginId);
            return true;
        }
    }
}
