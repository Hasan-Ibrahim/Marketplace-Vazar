namespace Data.Model
{
    public class DbModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DbModel()
        {
            IsDeleted = false;
        }
    }
}
