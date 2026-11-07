using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MVCGiza02.ViewModels
{
    // Custom class : 
    // definitions - action  -> View
    // Name (emp) - Dept name - Rate - skills - status ...
    public class EmpWithExtraInfoViewModel
    {
        public string EmpName { get; set; }
        public string DeptName { get; set; }

        public int Rate { get; set; }
        public List<string> Skills { get; set; }
        public string Status { get; set; }
    }
}
