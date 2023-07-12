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

            //var studentsDbContext = _context.Students.Include(s => s.Course);
            //return View(await studentsDbContext.ToListAsync());

            //IEnumerable<Student> lstsStudents = _context.STUDENT;
            //foreach (Student student in lstsStudents)
            //{
            //    student.Course = _context.COURSE.FirstOrDefault(iquery => iquery.Id == student.CourseID);
            //In the model we had a virtual course object in the student class. So that means each student
            //object has a course object. So we are saying here we are creating this object and defining its
            //value. The First/Default funtions returns the first instance of when the condition in the brackets 
            //is true. iQuery represents a temp object for the course. So it reads where course id (FROM THE COURSE TABLE
            //is equal to student.CourseID from the STUDENT TABLE. So its going to create that course object using that. 
            //}
            //return View(lstsStudents);
        }

        // GET: Students/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentsContacts = await _context.Students
        //        .Include(s => s.Course)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (studentsContacts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(studentsContacts);
        //}

        // GET: Students/Create
        //public IActionResult Create()
        //{
        //    ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
        //    return View();
        //}

        // Get: Upsert
        public IActionResult Upsert(int? id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                CourseSelectList = _context.Course.Select(iquery => new SelectListItem
                {
                    Text = iquery.Name,
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
                return View(studentViewModel);
            }
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DOB,EmailAddress,PhoneNumber,Image,CourseId")] StudentsContacts studentsContacts)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(studentsContacts);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentsContacts.CourseId);
        //    return View(studentsContacts);
        //}

        // GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentsContacts = await _context.Students.FindAsync(id);
        //    if (studentsContacts == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentsContacts.CourseId);
        //    return View(studentsContacts);
        //}

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DOB,EmailAddress,PhoneNumber,Image,CourseId")] StudentsContacts studentsContacts)
        //{
        //    if (id != studentsContacts.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(studentsContacts);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentsContactsExists(studentsContacts.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentsContacts.CourseId);
        //    return View(studentsContacts);
        //}

        // GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentsContacts = await _context.Students
        //        .Include(s => s.Course)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (studentsContacts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(studentsContacts);
        //}

        // POST: Students/Delete/5
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
