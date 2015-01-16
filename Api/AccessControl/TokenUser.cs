using System.Web;
using Data.TokenStorages;

namespace Api.AccessControl
{
    public class TokenUser
    {
        public readonly string Token;
        public readonly string LoginId;
        public readonly bool IsAuthenticated;
        public TokenUser(ITokenStorage tokenStorage)
        {
            Token = HttpContext.Current.Request.Headers.Get("authentication-tocken");
            if (!string.IsNullOrEmpty(Token))
            {
                LoginId = tokenStorage.GetLoginId(Token);
                IsAuthenticated = LoginId != null;
            }
            else
            {
                LoginId = null;
                IsAuthenticated = false;
            }
        }
    }
}