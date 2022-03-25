namespace Pog.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<CUser>? Users { get; set; }
    }
}
