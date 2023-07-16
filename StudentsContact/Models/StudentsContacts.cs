using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsContact.Models
{
	public class StudentsContacts
	{

        [Key]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? LastName { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime DOB { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "This Contact Field is Required.")]
        public string? EmailAddress { get; set; }

        [DisplayName("Phone Number")]
        [Column(TypeName = "nvarchar(100)")]
        public string? PhoneNumber { get; set; }

        public string? Image { get; set; }

        // Relationship

        [DisplayName("Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }

        public virtual Address? Address { get; set; }

        public virtual Grades? Grades { get; set; }
    }
}

