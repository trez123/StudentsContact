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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<StudentsContacts>()
        //        .HasOne(s => s.Address)
        //        .WithOne(m => m.StudentsContacts);

        //    modelBuilder.Entity<Address>()
        //        .HasOne(s => s.Parish)
        //        .WithMany(m => m.Address);

        //    modelBuilder.Entity<StudentsContacts>()
        //        .HasOne(s => s.Course)
        //        .WithMany(m => m.StudentsContacts);

        //    modelBuilder.Entity<StudentsContacts>()
        //        .HasOne(s => s.Grades)
        //        .WithOne(m => m.StudentsContacts);
        //}


    }
}

