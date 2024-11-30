using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Data;
using StudentPortal.Models.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.AspNetCore.Mvc.Diagnostics;
namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        //constructor assign in application dbcontext 
        //ApplicationDbContext is Like a container that has a tuple for each row in database
        public ApplicationDbContext dbcontext;
        public StudentsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        //displaying the registration form 
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        //actual form data taker with post request
        [HttpPost]
        //asynchronously performing post request that takes mod as parameter
        //mod is literally the data we got from the form they filled mod 
            //basically encaplustes them and brings it
        public async Task<IActionResult> AddStudent(AddStudentViewModel mod)
        {
            var student = new Student
            {
                Name = mod.Name,
                Phone = mod.Phone,
                Subscribed = mod.Subscribed,
                Email = mod.Email
            };
            //asynchronously add the data
            await dbcontext.Students.AddAsync(student);
            //save the data
            await dbcontext.SaveChangesAsync();
            //After saving the data to the database display the form as it is
            return View();
        }
    }
}
