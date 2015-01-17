using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class DbModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DbModel()
        {
            IsDeleted = false;
        }
    }
}
