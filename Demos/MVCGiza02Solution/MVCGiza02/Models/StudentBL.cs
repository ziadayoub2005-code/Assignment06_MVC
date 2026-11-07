using MVCGiza02.Data.DbContexts;

namespace MVCGiza02.Models
{
    public class StudentBL
    {
        DigitalDbContext context = new DigitalDbContext();

        // Sample data for students and their grades in courses
        private static List<Student> mockStudents = new List<Student>
        {
            new Student { Id = 1, Name = "Ahmed Ali", Age = 22, Address = "Giza" },
            new Student { Id = 2, Name = "Sara Mohamed", Age = 21, Address = "Cairo" },
            new Student { Id = 3, Name = "Omar Hassan", Age = 23, Address = "Alexandria" }
        };

        private static List<StudentCourse> mockResults = new List<StudentCourse>
        {
            new StudentCourse { StudentId = 1, CourseId = 1, Grade = 85 }, // Passed C# (Min 50)
            new StudentCourse { StudentId = 1, CourseId = 2, Grade = 45 }, // Failed MVC (Min 60)
            new StudentCourse { StudentId = 2, CourseId = 2, Grade = 90 }, // Passed MVC (Min 60)
            new StudentCourse { StudentId = 3, CourseId = 1, Grade = 30 }  // Failed C# (Min 50)
        };

        public Student? GetById(int id)
        {
            try
            {
                return context.Students.FirstOrDefault(s => s.Id == id) ?? mockStudents.FirstOrDefault(s => s.Id == id);
            }
            catch
            {
                return mockStudents.FirstOrDefault(s => s.Id == id);
            }
        }

        public StudentCourse? GetStudentCourse(int studentId, int courseId)
        {
            return mockResults.FirstOrDefault(r => r.StudentId == studentId && r.CourseId == courseId);
        }
    }
}
