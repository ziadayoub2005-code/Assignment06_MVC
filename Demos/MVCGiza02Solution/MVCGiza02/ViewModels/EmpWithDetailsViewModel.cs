using MVCGiza02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCGiza02.ViewModels
{
    // sources : Emp - List Dep
    public class EmpWithDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } 
        public decimal Salary { get; set; }
        public string? Title { get; set; }
        public string Address { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
