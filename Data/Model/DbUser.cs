namespace Data.Model
{
    public class DbUser : DbModel
    {
        public string LoginId { get; set; }
        public string HashedPassword { get; set; }

        public DbUser()
        {
            
        }

        public DbUser(string loginId, string hashedPassword)
        {
            LoginId = loginId;
            HashedPassword = hashedPassword;
        }
    }
}
