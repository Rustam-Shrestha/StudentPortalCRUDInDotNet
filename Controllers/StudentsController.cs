using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Data;
using StudentPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        // Constructor to assign ApplicationDbContext
        public ApplicationDbContext dbcontext;
        public StudentsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        // Displaying the registration form
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // Handling form data with POST request
        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel mod)
        {
            var student = new Student
            {
                Name = mod.Name,
                Phone = mod.Phone,
                Subscribed = mod.Subscribed,
                Email = mod.Email
            };
            // Asynchronously add the data
            await dbcontext.Students.AddAsync(student);
            // Save the data
            await dbcontext.SaveChangesAsync();
            // After saving the data to the database, display the form as it is
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentsList()
        {
            var listedStudents = await dbcontext.Students.ToListAsync();
            return View(listedStudents);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateList(Guid id)
        {
            // Asynchronously finding the data
            var foundStudent = await dbcontext.Students.FindAsync(id);
            return View(foundStudent);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateList(Student viewmodel)
        {
            // Asynchronously finding the data
            var foundStudent = await dbcontext.Students.FindAsync(viewmodel.Id);
            if (foundStudent is not null)
            {
                // Reassigning the tuples or found ones as something from viewmodel (updated data)
                foundStudent.Name = viewmodel.Name;
                foundStudent.Phone = viewmodel.Phone;
                foundStudent.Subscribed = viewmodel.Subscribed;
                foundStudent.Email = viewmodel.Email;

                await dbcontext.SaveChangesAsync();
            }
            // Returning the value in list format to the students controller
            return RedirectToAction("StudentsList", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student viewmodel)
        {
            // Asynchronously finding the data
            var foundStudent = await dbcontext.Students.FindAsync(viewmodel.Id);
            if (foundStudent is not null)
            {
                dbcontext.Students.Remove(foundStudent);
                await dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("StudentsList", "Students");
        }
    }
}