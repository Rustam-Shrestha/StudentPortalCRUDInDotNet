using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    //main purpose of this is to encapsulate the data generated from the form 
    public class AddStudentViewModel
    {
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public bool Subscribed { get; set; }
    }
}
