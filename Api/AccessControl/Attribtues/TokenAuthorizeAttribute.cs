using System.Web.Http;
using System.Web.Http.Controllers;
using Data.TokenStorages;

namespace Api.AccessControl.Attribtues
{
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            return TokenStorage.TokenExists(token.Scheme);
        }

        public ITokenStorage TokenStorage { get; set; }
    }
}