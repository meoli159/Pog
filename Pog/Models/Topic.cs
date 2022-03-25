namespace Pog.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsAnonymous { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreate { get; set; }

        [Required]
        public string? StaffId { get; set; }
        public virtual CUser? Staff { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }



    }
}
