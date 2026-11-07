using Microsoft.EntityFrameworkCore;
using MVCGiza02.Data.DbContexts;

namespace MVCGiza02.Models
{
    public class EmployeeBL
    {
        // open connectyion with DB 
        DigitalDbContext context = new DigitalDbContext();

        // Container for operations on DB 
        // 1-Get Details of Emp 
        public Employee GetById(int id)
        {
            return context.Employees
                .Include(E=>E.Dept)
                .FirstOrDefault(E => E.Id == id);
        }

        // 2-Get all Emps .. 
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        // 3-Save to DB 
        public void SaveInDB()
        {
            context.SaveChanges();
        }

        // 4 Update 
        //public void UpdateDB(Employee Emp)
        //{
        //    // update to local 
        //    context.Employees.Update(Emp);
        //    // update to DB 
        //    context.SaveChanges();
        //}

        // 4- Delete
        public void Delete(Employee Emp)
        {
            // delete from Local 
            context.Employees.Remove(Emp);
            // delete from DB
            context.SaveChanges();
        }

        // 5- Add 
        public void Add(Employee emp)
        {
            // add to local
            context.Employees.Add(emp);
            // add to DB
            context.SaveChanges();
        }
    }
}
