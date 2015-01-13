using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class OAuthController : Controller
    {
        private string _clientId = ConfigurationManager.AppSettings["oauthclientid-google"];
        private string _clientSecret = ConfigurationManager.AppSettings["oauthclientsecret-google"];

        private string RedirectUri { get { return Url.Action("GoogleSignInSuccess", "OAuth", null, Request.Url.Scheme); } }
        public ActionResult GoogleSignIn()
        {
            Session["googleoouthsecuritystate"] = Guid.NewGuid().ToString();
            var url =
                string.Format("https://accounts.google.com/o/oauth2/auth?" +
                              "client_id={0}&" +
                              "response_type=code&" +
                              "scope=openid%20email&" +
                              "redirect_uri={1}&" +
                              "state={2}"
                , _clientId, RedirectUri, Session["googleoouthsecuritystate"]);

            return Redirect(url);
        }

        public ActionResult GoogleSignInSuccess(string state, string code)
        {
            var storedState = Session["googleoouthsecuritystate"];
            if (state == null || storedState == null || !state.Equals(storedState))
            {
                return Content("Failed");
            }

            var postData = HttpUtility.ParseQueryString(String.Empty);
            postData.Add("code", code);
            postData.Add("client_id", _clientId);
            postData.Add("client_secret", _clientSecret);
            postData.Add("redirect_uri", RedirectUri);
            postData.Add("grant_type", "authorization_code");

            var postBytes = Encoding.ASCII.GetBytes(postData.ToString());

            var request = WebRequest.Create("https://www.googleapis.com/oauth2/v3/token");
            request.ContentType = "application/x-www-form-urlencoded";

            request.GetRequestStream().Write(postBytes, 0, postBytes.Length);

            request.Method = "POST";

            var response = request.GetResponse().GetResponseStream();

            return Content("Done");
        }
    }
}