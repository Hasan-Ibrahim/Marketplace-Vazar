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
            if (cookieString == null)
            {
                return null;
            }
            var cookieContainer = new CookieContainer();

            var url = new Uri("http://dummy.com");

            cookieContainer.SetCookies(url, cookieString);

            var cookies = cookieContainer.GetCookies(url);

            var cookie = cookies[CookieKey];
            return cookie != null ? cookie.Value : null;
        }
    }
}