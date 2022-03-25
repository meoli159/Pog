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
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public string? Address { get; set; }

        //public Role? Role { get; set; }
        public int? DepartmentId { get; set; }           
        public virtual Department? Department { get; set; }

        public virtual ICollection<Topic>? Topics { get; set; }


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
