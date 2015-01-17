using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Api.AccessControl
{
    public class AuthenticationCookieHandler
    {
        public static readonly string CookieKey = "authentication";

        public HttpResponseMessage GetAuthenticatedResponse(string token)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var authenticationKookie = new CookieHeaderValue(CookieKey, token)
            {
                Expires = DateTime.Now.AddDays(1)
            };

            response.Headers.AddCookies(new[] { authenticationKookie });
            return response;
        }

        public string GetTokenFromRequest()
        {
            var cookieString = HttpContext.Current.Request.Headers.Get("Cookie");
            var cookieContainer = new CookieContainer();

            cookieContainer.SetCookies(HttpContext.Current.Request.Url, cookieString);

            var cookies = cookieContainer.GetCookies(HttpContext.Current.Request.Url);

            var cookie = cookies[CookieKey];
            return cookie != null ? cookie.Value : null;
        }
    }
}