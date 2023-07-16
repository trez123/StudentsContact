using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsContact.Models
{
	public class Course
	{
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [DisplayName("Max Student")]
        public int MaxStudent { get; set; }

        public ICollection<StudentsContacts>? StudentsContacts { get; set; }
    }
}

