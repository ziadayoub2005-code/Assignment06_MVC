using Microsoft.EntityFrameworkCore;
using MVCGiza02.Data.DbContexts;

namespace MVCGiza02.Models
{
    public class CourseBL
    {
        DigitalDbContext context = new DigitalDbContext();

        // In-memory data store for fallback when database is not connected
        private static List<Course> mockCourses = new List<Course>
        {
            new Course { Id = 1, Name = "C# Programming", Degree = 100, MinDegree = 50, Hours = 40 },
            new Course { Id = 2, Name = "ASP.NET Core MVC", Degree = 100, MinDegree = 60, Hours = 45 },
            new Course { Id = 3, Name = "SQL Server", Degree = 100, MinDegree = 50, Hours = 30 }
        };

        // 1- Get all courses
        public List<Course> GetAll()
        {
            try
            {
                return context.Courses.Include(c => c.Dept).ToList();
            }
            catch
            {
                return mockCourses;
            }
        }

        // 2- Get course by ID
        public Course? GetById(int id)
        {
            try
            {
                return context.Courses.Include(c => c.Dept).FirstOrDefault(c => c.Id == id);
            }
            catch
            {
                return mockCourses.FirstOrDefault(c => c.Id == id);
            }
        }

        // 3- Add new course
        public void Add(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
            catch
            {
                course.Id = mockCourses.Any() ? mockCourses.Max(c => c.Id) + 1 : 1;
                mockCourses.Add(course);
            }
        }

        // 4- Update existing course
        public void Update(Course course)
        {
            try
            {
                var existing = context.Courses.FirstOrDefault(c => c.Id == course.Id);
                if (existing != null)
                {
                    existing.Name = course.Name;
                    existing.Degree = course.Degree;
                    existing.MinDegree = course.MinDegree;
                    existing.Hours = course.Hours;
                    existing.DeptId = course.DeptId;
                    context.SaveChanges();
                }
            }
            catch
            {
                var existing = mockCourses.FirstOrDefault(c => c.Id == course.Id);
                if (existing != null)
                {
                    existing.Name = course.Name;
                    existing.Degree = course.Degree;
                    existing.MinDegree = course.MinDegree;
                    existing.Hours = course.Hours;
                    existing.DeptId = course.DeptId;
                }
            }
        }

        // 5- Delete course
        public void Delete(int id)
        {
            try
            {
                var course = context.Courses.Find(id);
                if (course != null)
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }
            }
            catch
            {
                var course = mockCourses.FirstOrDefault(c => c.Id == id);
                if (course != null)
                {
                    mockCourses.Remove(course);
                }
            }
        }
    }
}
