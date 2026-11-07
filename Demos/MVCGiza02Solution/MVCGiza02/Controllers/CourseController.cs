using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCGiza02.Models;
using MVCGiza02.ViewModels;

namespace MVCGiza02.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();
        DepartmentBL departmentBL = new DepartmentBL();
        StudentBL studentBL = new StudentBL();

        // -------------------------------------------------------------
        // Question 2: CRUD Operations with Server-side & Client-side Validation
        // -------------------------------------------------------------

        // 1- Read: Get all courses
        // GET: /Course/Index
        public IActionResult Index()
        {
            var courses = courseBL.GetAll();
            return View("Index", courses);
        }

        // 2- Read: Get single course details
        // GET: /Course/Details/5
        public IActionResult Details(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Details", course);
        }

        // 3- Create: Open empty Add form
        // GET: /Course/Add
        public IActionResult Add()
        {
            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View("Add");
        }

        // 3- Create: Save new course (with Server-side validation)
        // POST: /Course/SaveAdd
        [HttpPost]
        public IActionResult SaveAdd(Course course)
        {
            // Custom business validation rule: MinDegree cannot exceed total Degree
            if (course.MinDegree >= course.Degree)
            {
                ModelState.AddModelError("MinDegree", "Min Degree must be less than Total Degree");
            }

            // Server-side validation check
            if (ModelState.IsValid)
            {
                courseBL.Add(course);
                return RedirectToAction(nameof(Index));
            }

            // If invalid, reload dropdown and return view with validation messages
            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View("Add", course);
        }

        // 4- Update: Open Edit form populated with course data
        // GET: /Course/Edit/5
        public IActionResult Edit(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(), "Id", "Name", course.DeptId);
            return View("Edit", course);
        }

        // 4- Update: Save edited course (with Server-side validation)
        // POST: /Course/SaveEdit/5
        [HttpPost]
        public IActionResult SaveEdit(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            // Custom business validation
            if (course.MinDegree >= course.Degree)
            {
                ModelState.AddModelError("MinDegree", "Min Degree must be less than Total Degree");
            }

            // Server-side validation check
            if (ModelState.IsValid)
            {
                courseBL.Update(course);
                return RedirectToAction(nameof(Index));
            }

            // If validation failed, re-populate dropdown and redisplay form
            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(), "Id", "Name", course.DeptId);
            return View("Edit", course);
        }

        // 5- Delete: Open confirmation page
        // GET: /Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Delete", course);
        }

        // 5- Delete: Confirm and remove from DB
        // POST: /Course/ConfirmDelete/5
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            courseBL.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // -------------------------------------------------------------
        // Question 3: Action takes (studentId, courseId)
        // Passes pre-computed Color and Status into ViewModel -> NO CONDITIONS IN VIEW!
        // GET: /Course/Result?studentId=1&courseId=2
        // -------------------------------------------------------------
        public IActionResult Result(int studentId, int courseId)
        {
            var student = studentBL.GetById(studentId) ?? new Student { Id = studentId, Name = "Ahmed Ali" };
            var course = courseBL.GetById(courseId) ?? new Course { Id = courseId, Name = "ASP.NET Core MVC", Degree = 100, MinDegree = 60 };

            var record = studentBL.GetStudentCourse(studentId, courseId);
            int studentGrade = record != null ? record.Grade : 75; // sample score if no record

            // Business logic in Controller (Action), NOT in View:
            bool isPassed = studentGrade >= course.MinDegree;

            var viewModel = new StudentCourseResultViewModel
            {
                StudentId = student.Id,
                StudentName = student.Name,
                CourseId = course.Id,
                CourseName = course.Name,
                Degree = studentGrade,
                MinDegree = course.MinDegree,
                Color = isPassed ? "green" : "red",
                Status = isPassed ? "Passed" : "Failed",
                CssClass = isPassed ? "text-success" : "text-danger"
            };

            return View("Result", viewModel);
        }
    }
}
