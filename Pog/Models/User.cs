using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pog.Models
{

    public enum Gender { Male, Female, Other }
    public enum Role { Admin, Staff, QAManager, QACoordinator }

    public class CUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public string? Address { get; set; }

        public Role? Role { get; set; }

        //public Role? Role { get; set; }
        public int? DepartmentId { get; set; }           
        public virtual Department? Department { get; set; }

        public virtual ICollection<Topic>? Topics { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }

    [Table("Staff")]
    public class Staff : CUser
    {

    }

    [Table("QA")]
    public class QA : CUser
    {

    }

 



}
