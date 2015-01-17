using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.AccessControl
{
    public class AuthenticationResponse : HttpResponseMessage
    {
        public static readonly string CookieKey = "$$authentication$$";
        public AuthenticationResponse(string value)
            : base(HttpStatusCode.OK)
        {
            var authenticationKookie = new CookieHeaderValue(CookieKey, value)
            {
                Expires = DateTime.Now.AddDays(1)
            };

            Headers.AddCookies(new[] { authenticationKookie });
        }
    }
}