using System;
using Microsoft.EntityFrameworkCore;

namespace StudentsContact.Models
{
	public class StudentsDbContext : DbContext
	{
		public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
		{ }

		public DbSet<StudentsContacts> Students { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Parish> Parish { get; set; }
		public DbSet<Course> Course { get; set; }
		public DbSet<Grades> Grades { get; set; }
    }
}

