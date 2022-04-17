namespace Pog.Models.ViewModel
{
    public class CommentViewModel
    {
        public int? TopicId { get; set; }
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        public bool IsAnonymous { get; set; }


        public int TopicDueDateId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CommentDueDate { get; set; }
        public virtual TopicDueDate? TopicDueDate { get; set; }

        public int UserId { get; set; }
        public virtual CUser? User { get; set; }

    }
}
