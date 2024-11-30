using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    // Making new identifier for a single student entity
    public class Student
    {
        // Unique identifier
        [Key]
        public Guid Id { get; set; }

        [Required]
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