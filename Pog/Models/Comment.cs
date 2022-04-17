namespace Pog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreate { get; set; }

        public bool IsAnonymous { get; set; }

    
        public virtual CUser? User { get; set; }

        public int TopicDueDateId { get; set; }
        public TopicDueDate? TopicDueDate { get; set; }
    }
}
