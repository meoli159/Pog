namespace Pog.Models
{
    public class TopicDueDate
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DueDate{ get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FinalDate { get; set; }

        public virtual ICollection<Topic>? TopicList { get; set; }
        public ICollection<Comment>? CommentList { get; set; }
    }
}
