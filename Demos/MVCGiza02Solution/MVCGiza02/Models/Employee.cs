using MVCGiza02.Validators;
using System.ComponentModel.DataAnnotations;

namespace MVCGiza02.Models
{
    // after .net 6 : 
    // Nullable ref types !!
    // represent business ...

    // required to store data about it !

    // design model : View or domain :
    // 1-Property displayed? - Data type appended to input?
    // 2-validation criteria (Model Validation) - Controller(ModelState)
    // 3-error message Visualized - Customise error message
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Full Name")]
        [Required(ErrorMessage ="Req")]
        [MaxLength(30,ErrorMessage ="Less than 30")]
        [MinLength(3,ErrorMessage ="More than 3")]
        [RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage ="Must be characters and spaces")]
        [UniqueName(ErrorMessage ="Not Unique !")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Req")]
        [Range(7000,20000,ErrorMessage ="between 7000 and 20000")]
        public decimal Salary { get; set; }

        public string? Title { get; set; }

        [Required(ErrorMessage ="Req")]
        [MinLength(3,ErrorMessage ="More than 3")]
        [MaxLength(50,ErrorMessage ="less than 50")]
        public string Address { get; set; }

        [Display(Name="Department")]
        [Required(ErrorMessage ="Req")]
        [Range(1,int.MaxValue,ErrorMessage ="Enter Valid Department")]
        // FK 
        public int DeptId { get; set; }

        // has a department
        public Department? Dept { get; set; }
    }
}
