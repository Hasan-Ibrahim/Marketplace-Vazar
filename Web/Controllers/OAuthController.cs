using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    public class OAuthController : Controller
    {
        private readonly string _googleClientId = ConfigurationManager.AppSettings["oauthclientid-google"];
        private readonly string _googleClientSecret = ConfigurationManager.AppSettings["oauthclientsecret-google"];

        private readonly string _facebookClientId = ConfigurationManager.AppSettings["oauthclientid-facebook"];
        private readonly string _facebookClientSecret = ConfigurationManager.AppSettings["oauthclientsecret-facebook"];

        private string GoogleRedirectUri { get { return Url.Action("GoogleSignInSuccess", "OAuth", null, Request.Url.Scheme); } }
        private string FacebookRedirectUri { get { return Url.Action("FacebookSignInSuccess", "OAuth", null, Request.Url.Scheme); } }

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
                , _googleClientId, GoogleRedirectUri, Session["googleoouthsecuritystate"]);

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
            postData.Add("client_id", _googleClientId);
            postData.Add("client_secret", _googleClientSecret);
            postData.Add("redirect_uri", GoogleRedirectUri);
            postData.Add("grant_type", "authorization_code");

            var postBytes = Encoding.ASCII.GetBytes(postData.ToString());

            var request = WebRequest.Create("https://www.googleapis.com/oauth2/v3/token");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            request.GetRequestStream().Write(postBytes, 0, postBytes.Length);

            var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            var r = new JavaScriptSerializer().Deserialize<GoogleOAuthResponse>(response);

            var idTockenParts = r.id_token.Split('.');
            var idTokenBase64 = FixBase64String(idTockenParts[1]);
            var data = Convert.FromBase64String(FixBase64String(idTokenBase64));
            var idToken = new JavaScriptSerializer().Deserialize<GooglaOAuthIdTocken>(Encoding.UTF8.GetString(data));

            if (idToken.email_verified)
            {
                FormsAuthentication.SetAuthCookie(idToken.email, false);                
            }

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult FacebookSignIn()
        {
            Session["facebookouthsecuritystate"] = Guid.NewGuid().ToString();
            var url =
                string.Format("https://www.facebook.com/dialog/oauth?" +
                              "client_id={0}&" +
                              "response_type=code&" +
                              "scope=public_profile&" +
                              "redirect_uri={1}&" +
                              "state={2}"
                , _facebookClientId, FacebookRedirectUri, Session["facebookouthsecuritystate"]);

            return Redirect(url);
        }
/*

        public ActionResult FacebookSignInSuccess(string state, string code)
        {
            var storedState = Session["facebookouthsecuritystate"];
            if (state == null || storedState == null || !state.Equals(storedState))
            {
                return Content("Failed");
            }

            var postData = HttpUtility.ParseQueryString(String.Empty);
            postData.Add("code", code);
            postData.Add("client_id", _facebookClientId);
            postData.Add("client_secret", _facebookClientSecret);
            postData.Add("redirect_uri", GoogleRedirectUri);
            postData.Add("grant_type", "authorization_code");

            var url =
                string.Format("https://www.facebook.com/dialog/oauth?" +
                              "client_id={0}&" +
                              "redirect_uri={1}&" +
                              "response_type=code&" +
                              "scope=public_profile&" +
                              
                              "state={2}"
                , _facebookClientId, FacebookRedirectUri, Session["facebookouthsecuritystate"]);


            var request = WebRequest.Create("https://graph.facebook.com/oauth/access_token?");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            request.GetRequestStream().Write(postBytes, 0, postBytes.Length);

            var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            var r = new JavaScriptSerializer().Deserialize<GoogleOAuthResponse>(response);

            var idTockenParts = r.id_token.Split('.');
            var idTokenBase64 = FixBase64String(idTockenParts[1]);
            var data = Convert.FromBase64String(FixBase64String(idTokenBase64));
            var idToken = new JavaScriptSerializer().Deserialize<GooglaOAuthIdTocken>(Encoding.UTF8.GetString(data));

            if (idToken.email_verified)
            {
                FormsAuthentication.SetAuthCookie(idToken.email, false);
            }

            return RedirectToAction("Index", "Home");
        }
*/


        private string FixBase64String(string base64String)
        {
            base64String = base64String.Replace('-', '+').Replace('_', '/').Replace(" ", "");
            var extraCharacters = base64String.Length % 4;
            if (extraCharacters != 0)
            {
                base64String += new string('=', 4 - extraCharacters);
            }

            return base64String;
        }
    }
}