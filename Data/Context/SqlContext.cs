using System.Configuration;
using System.Data.Entity;
using Data.Model;

namespace Data.Context
{
    class SqlContext : DbContext
    {
        public SqlContext() : base(ConfigurationManager.AppSettings["SqlConnection"])
        {
        }
        static SqlContext()
        {
            Database.SetInitializer<SqlContext>(null);
        }
        public DbSet<DbUser> Users { get; set; } 
    }
}
