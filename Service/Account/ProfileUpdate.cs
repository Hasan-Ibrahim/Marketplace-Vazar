
using System.ComponentModel.DataAnnotations;

namespace Service.Account
{
    public class ProfileUpdate
    {
        public string FullName { get; set; }
        
        public string OldPassword { get; set; }
        
        public string NewPassword { get; set; }
        
        [Compare("NewPassword")]
        public string RetypeNewPassword { get; set; }
    }
}