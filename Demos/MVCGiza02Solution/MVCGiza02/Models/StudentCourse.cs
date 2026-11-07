namespace MVCGiza02.Models
{
    // Junction class between Student and Course with Grade (Payload)
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int Grade { get; set; }
    }
}
