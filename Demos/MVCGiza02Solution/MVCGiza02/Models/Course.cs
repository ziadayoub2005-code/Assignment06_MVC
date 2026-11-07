using System.ComponentModel.DataAnnotations;

namespace MVCGiza02.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [MinLength(2, ErrorMessage = "Course Name must be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Course Name cannot exceed 50 characters")]
        [Display(Name = "Course Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Total degree is required")]
        [Range(50, 100, ErrorMessage = "Total Degree must be between 50 and 100")]
        [Display(Name = "Total Degree")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "Minimum passing degree is required")]
        [Range(20, 60, ErrorMessage = "Min Degree must be between 20 and 60")]
        [Display(Name = "Minimum Passing Degree")]
        public int MinDegree { get; set; }

        [Range(1, 120, ErrorMessage = "Hours must be between 1 and 120")]
        [Display(Name = "Credit Hours")]
        public int Hours { get; set; }

        [Display(Name = "Department")]
        public int? DeptId { get; set; }

        public Department? Dept { get; set; }
    }
}
