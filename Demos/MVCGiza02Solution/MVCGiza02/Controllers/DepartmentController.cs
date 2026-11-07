using Microsoft.AspNetCore.Mvc;
using MVCGiza02.Models;

namespace MVCGiza02.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();
        // Container for actions handle req to Department model ...

        // View : All Departments : 

        // 1-Req Handler > Route mapping > Req URL 
        // 2-BL Coordinate / Decide data to be fetched or operations done 
        // 3-Provide response : Select View - dend data fetched to view

        // Req URL 
        // /Department/Index
        public IActionResult Index()
        {
            // BL Coordinate : 
            List<Department> Depts = departmentBL.GetAll();
            // Provide response :
            return View("Index", Depts);
        }

        // EF core by Default not load Realted entities Data ?!
        // Loading 
        // Explicit Loading


        // self : 
        // How ? - 2 use cases ? - before Core Vs after Core ? 
        // Explicit Loading probelm N+1 ?
        // eager Loading 
        // Lazy Loading

        // Data !! 
        // Mapping Data in Req === Model Binding !! 

        // Req LifeCycle : 
        // Opeartion on DB - Add depaertment ...
        // /Department/Add?Name=SD&Mgrname=Jo

        // 1- UX : New - Index
        // 2- Add action : open form only 
        // 3- View : Form : enter Dept Data !!
        // 4- SaveAdd action : save data to DB

        // /Department/Add
        public IActionResult Add()
        {
            return View("Add"); // model ? null
        }

        // /Department/SaveAdd?Name=ali&Mgrname=Ismail
        public IActionResult SaveAdd(Department Dept)
        {
            // validate User : Business Logic 
            if (Dept.Name != null)
            {
                // Save to DB
                // BL 
                departmentBL.Add(Dept);
                // if Saved (return to Index)
                return RedirectToAction(nameof(Index));
            }
            return View("Add",Dept); // model ? Department
        }
    }
}
