using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsContact.Models
{
	public class Address
	{
        [Key]
        public int Id { get; set; }

        [DisplayName("Address")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Field is Required.")]
        public string? AddresLine { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Field is Required.")]
        public string? City { get; set; }

        public int ParishId { get; set; }

        [ForeignKey("ParishId")]
        public virtual Parish? Parish { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentsContacts? StudentsContacts { get; set; }
    }
}

