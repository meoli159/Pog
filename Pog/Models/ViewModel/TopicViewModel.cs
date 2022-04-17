namespace Pog.Models.ViewModel
{
    public class TopicViewModel
    {
        public int DueDateId { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime TopicDueDate { get; set; }

        public bool IsAnonymous { get; set; }

        public int UserId { get; set; }
        public virtual CUser? User { get; set; }
    }
}
