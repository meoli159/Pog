namespace Pog.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAnonymous { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

               
        public virtual CUser? User { get; set; }

        [Required]  
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        //Attachment
        [DataType(DataType.Upload)]
        [Display(Name = " Upload file")]
        public string? TopicAttachments { get; set; }
        [Display(Name = " Attachment Name")]
        public string?TopicAttachmentName { get; set; }

        
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree with Terms And Conditions!!")]
        public bool TermAndCondition { get; set; }

        public int TopicDueDateId { get; set; }
        public virtual TopicDueDate? TopicDueDate { get; set; }

        public ICollection<Comment>? Comments { get; set; }

       
    }


}
