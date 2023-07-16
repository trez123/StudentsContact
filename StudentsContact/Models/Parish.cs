using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsContact.Models
{
	public class Parish
	{
        [Key]
        public int Id { get; set; }

        [DisplayName("State/Parish")]
        [Column(TypeName = "nvarchar(100)")]
        public string? StateParish { get; set; }

        public ICollection<Address>? Address { get; set; }
    }
}

