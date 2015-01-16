namespace Web.Models
{
    public class GooglaOAuthIdToken
    {
        public string iss { get; set; }
        public string at_hash { get; set; }
        public bool email_verified { get; set; }
        public string sub { get; set; }
        public string azp { get; set; }
        public string email { get; set; }
        public string aud { get; set; }
        public string iat { get; set; }
        public string exp { get; set; }
    }
}