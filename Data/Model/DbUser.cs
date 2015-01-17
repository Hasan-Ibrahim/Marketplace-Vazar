using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("app.User")]
    public class DbUser : DbModel
    {
        public string LoginId { get; set; }
        public string HashedPassword { get; set; }
        public string FullName { get; set; }

        public DbUser()
        {
            
        }

        public DbUser(string loginId, string hashedPassword)
        {
            LoginId = loginId;
            HashedPassword = hashedPassword;
        }

        public DbUser(string loginId, string hashedPassword, string fullName): this(loginId, hashedPassword)
        {
            FullName = fullName;
        }
    }
}
