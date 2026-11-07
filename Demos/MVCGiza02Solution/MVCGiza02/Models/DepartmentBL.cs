using Microsoft.EntityFrameworkCore;
using MVCGiza02.Data.DbContexts;

namespace MVCGiza02.Models
{
    public class DepartmentBL
    {
        // Open Connection !
        DigitalDbContext context = new DigitalDbContext();
        // Container Operations/queries/BL on Department model !

        // Get all 
        // function 
        public List<Department> GetAll()
        {
            return context.Departments.Include(D => D.Emps).ToList();
        }

        // Add 
        public void Add(Department dept)
        {
            // Add to local
            context.Departments.Add(dept);
            // add to DB
            context.SaveChanges();
        }
    }
}
