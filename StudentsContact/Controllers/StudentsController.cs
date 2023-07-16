using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsContact.Models;
using StudentsContact.Models.ViewModels;



namespace StudentsContact.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentsController(StudentsDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        // GET: Students
        public IActionResult Index()
        {
            IEnumerable<StudentsContacts> studentList = _context.Students;
            foreach (StudentsContacts student in studentList)
            {
                student.Course = _context.Course.FirstOrDefault(iquery => iquery.Id == student.CourseId);
            }
            return View(studentList);
        }

        // Get: Upsert
        public IActionResult Upsert(int? id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                CourseSelectList = _context.Course.Select(iquery => new SelectListItem
                {
                    Text = iquery.Name,
                    Value = iquery.Id.ToString()
                }),
                ParishSelectList = _context.Parish.Select(iquery => new SelectListItem
                {
                    Text = iquery.StateParish,
                    Value = iquery.Id.ToString()
                })

            };
            if (id == null)
            {
                return View(studentViewModel);
            }
            else
            {
                studentViewModel.StudentsContacts = _context.Students.Find(id);
                if (studentViewModel.StudentsContacts == null)
                {
                    return NotFound();
                }
                return View(studentViewModel);
            }
        }

        //POST: Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webroot = _webHostEnvironment.WebRootPath;

                if (studentViewModel.StudentsContacts.Id == 0)
                {
                    string uploadpath = webroot + AppConst.UploadPath;
                    if (!Directory.Exists(uploadpath))
                    {
                        Directory.CreateDirectory(uploadpath);
                    }
                    string fileName = Guid.NewGuid().ToString();
                    string ext = Path.GetExtension(files[0].FileName);
                    using (var fs = new FileStream(Path.Combine(uploadpath, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(fs);
                    }
                    studentViewModel.StudentsContacts.Image = fileName + ext;
                    _context.Students.Add(studentViewModel.StudentsContacts);
                }
                else
                {
                    _context.Students.Update(studentViewModel.StudentsContacts);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                studentViewModel.CourseSelectList = _context.Course.Select(iquery => new SelectListItem
                {
                    Text = iquery.Name,
                    Value = iquery.Id.ToString()

                });
                studentViewModel.ParishSelectList = _context.Parish.Select(iquery => new SelectListItem
                {
                    Text = iquery.StateParish,
                    Value = iquery.Id.ToString()
                });
                return View(studentViewModel);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'StudentsDbContext.Students'  is null.");
            }
            var studentsContacts = await _context.Students.FindAsync(id);
            if (studentsContacts != null)
            {
                _context.Students.Remove(studentsContacts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsContactsExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
