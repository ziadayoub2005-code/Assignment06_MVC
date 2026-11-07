namespace MVCGiza02.ViewModels
{
    // ViewModel designed for Question 3:
    // Holds Student Name, Course Name, Degree, and Pre-calculated Color & Status
    // so the View does NOT contain any @if conditions!
    public class StudentCourseResultViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;

        public int Degree { get; set; }
        public int MinDegree { get; set; }

        // Presentation logic evaluated in Action:
        public string Color { get; set; } = "green";        // "green" or "red"
        public string Status { get; set; } = "Passed";       // "Passed" or "Failed"
        public string CssClass { get; set; } = "text-success"; // Bootstrap helper class
    }
}
