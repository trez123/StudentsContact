using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsContact.Models
{
	public class Grades
	{
        [Key]
        public int Id { get; set; }

        [DisplayName("Physical Education Grade (Practical)")]
        [Column(TypeName = "nvarchar(100)")]
        public string? PhysicalEducation { get; set; }

        [DisplayName("Industrial Technology Grade (Practical)")]
        [Column(TypeName = "nvarchar(100)")]
        public string? IndustrialTechnology { get; set; }

        [DisplayName("Physics Grade (Theory)")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Physics { get; set; }

        [DisplayName("Math Grade (Theory)")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Math { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentsContacts? StudentsContacts { get; set; }
    }
}

