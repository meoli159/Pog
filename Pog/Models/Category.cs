namespace Pog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Topic>? Topics { get; set; }

    }
}
