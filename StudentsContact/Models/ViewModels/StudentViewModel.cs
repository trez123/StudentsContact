using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsContact.Models.ViewModels
{
	public class StudentViewModel
	{
		public virtual StudentsContacts StudentsContacts { get; set; }
		public virtual Address Address { get; set; }
		public virtual IEnumerable<SelectListItem>? CourseSelectList { get; set; }
        public virtual IEnumerable<SelectListItem>? ParishSelectList { get; set; }
    }
}

