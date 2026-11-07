using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCGiza02.Data.DbContexts;
using MVCGiza02.Models;
using MVCGiza02.ViewModels;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MVCGiza02.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBL employeeBL = new EmployeeBL();
        DepartmentBL departmentBL = new DepartmentBL();

        // Container BL on Employee model ...

        // 1-Req Handler > Route mapping > Req URL 
        // 2-BL Coordinate / Decide data to be fetched or operations done 
        // 3-Provide response : Select View - dend data fetched to view


        // send more than one info ?!  -  Model (one value)
        // send more than one value - Property - Type ?
        // Collection
        // Properties : hold more than one value - Any info
        // ViewData : no prior definition
        //            fast lookup
        //            Dictionary <key, value>
        // <key, value>    ---   <string, object>

        // Set values : 

        // ViewBag : Dictionary<string, object>
        // dynamic Wrapper ... 
        // Runtime Detect this types !

        // ViewBag / viewdata >> read and set  in same dictionary !
        // set in ViewData > Get in viewBag 

        // ViewData["Rate"] = Rate;
        // ViewBag.Rate = Rate;


        // ViewBag / ViewData ? 
        // business / system 
        // small pieces of info > page title - ... 

        // ViewModel
        // Custom Class : 
        // data needed - action > view 
        // 1- customization : 
        // select some prop from model -> light object -> quick response
        // shape/tailor response needed !
        // merge data from more than one model > complex response
        // 2- Security :
        // apis -> its about data ! -> definitions different
        // 3- Separation of Concern !
        // ViewModel(Sent to view)  -  Model(System)
        // Data Validations - attributes - Clean Design
        // CQRS   ---  ReadViewModel - WriteViewModel : self

        // ViewModel : 
        // EmpName - DeptName - Rate - Status - Skills - ... 
        // 1- ViewMdoel Class ...
        // 2- Action based on model / ViewModel !
        // 2-1 Prepare Sources Data ..
        // 2-2 prepare ViewModel(Destination)
        // 2-3 allocate data (Manual Mapping)


        // /Employee/Details?id=1
        // Action : based on model !
        public IActionResult Details(int id)
        {
            // BL Coordinate 
            Employee emp = employeeBL.GetById(id);
            // Provide response
            int Rate = 67;
            string Status = "B";
            List<string> Skills = new List<string> { "teamwork", "communication" };

            ViewData["Rate"] = Rate;
            ViewData["Status"] = Status;
            ViewData["Skills"] = Skills;

            return View("Details", emp);
        }


        // /Employee/DetailsVM?id=1
        // Action : based on viewmodel 
        public IActionResult DetailsVM(int id)
        {
            // Sources of diff info 
            Employee Emp = employeeBL.GetById(id);
            int Rate = 67;
            string Status = "B";
            List<string> Skills = new List<string> { "teamwork", "communication" };
            // ViewModel(Destination)
            // Mapping btw Sources and destination
            EmpWithExtraInfoViewModel EVM = new EmpWithExtraInfoViewModel()
            {
                EmpName = Emp.Name,
                DeptName = Emp.Dept.Name,
                Rate = Rate,
                Status = Status,
                Skills = Skills
            };

            return View("DetailsVM", EVM); // ViewModel
        }

        // Index : life cycle of get all Emps : 
        // Req handle - Coordinate BL - Provide response
        // /Employee/Index
        public IActionResult Index()
        {
            return View("Index", employeeBL.GetAll());
        }

        // Edit action : open Page
        // based on ViewModel ....
        public IActionResult Edit(int id)
        {
            // Sources : 
            Employee Emp = employeeBL.GetById(id);
            List<Department> Depts = departmentBL.GetAll();
            // Destination 
            EmpWithDetailsViewModel EDVM = new EmpWithDetailsViewModel();
            // Mapping (Manual)   --  Auto mapper
            EDVM.Id = Emp.Id;
            EDVM.Name = Emp.Name;
            EDVM.Address = Emp.Address;
            EDVM.Salary = Emp.Salary;
            EDVM.Title = Emp.Title;
            EDVM.DeptId = Emp.DeptId;
            EDVM.DeptList = Depts;

            return View("Edit", EDVM); // Model Employee
        }

        // /Employee/saveEdit 
        public IActionResult SaveEdit(Employee empSent, int id)
        {
            // validation 
            //if (empSent.Name != null)
            if(ModelState.IsValid)
            {
                // Save To DB
                Employee OldEmp = employeeBL.GetById(id);
                // Update to local (Controller)
                OldEmp.Name = empSent.Name;
                OldEmp.Salary = empSent.Salary;
                OldEmp.Title = empSent.Title;
                OldEmp.Address = empSent.Address;
                OldEmp.DeptId = empSent.DeptId;
                // update to DB -> Context -> BL -> model
                employeeBL.SaveInDB();
                // if Saved ...
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", empSent);
        }

        // delete : open alert Page ..
        // /Employee/Delete/2
        public IActionResult Delete(int id)
        {
            return View("Delete", employeeBL.GetById(id)); // employee
        }

        public IActionResult ConfirmDelete(int id)
        {
            Employee Emp = employeeBL.GetById(id);

            if (Emp != null)
            {
                // Delete from DB
                // Context -> BL 
                employeeBL.Delete(Emp);
                // if deleted 
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        // Add : open Add form 
        // /employe/Add 
        public IActionResult Add()
        {
            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(),"Id", "Name");
            return View("Add"); // model null
        }

        // /employee/SaveAdd?Name=ali&age=30 ...
        [HttpPost]
        public IActionResult SaveAdd(Employee emp)
        {
            //if (emp.Name != null & emp.Salary > 7000 & emp.DeptId != 0)
            if(ModelState.IsValid)
            {
                // Save to DB
                // context -> BL -> 
                employeeBL.Add(emp);
                // if saved 
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptList"] = new SelectList(departmentBL.GetAll(), "Id", "Name"); 
            return View("Add", emp); // model employee
        }


        // Edit LifeCycle and Delete life cycle 

        // Edit Life cycle
        // 1- UX : Index - hyper Link 
        // for each record - anchor 
        // 2- Edit action : open Edit Page/Form
        // 3- View : Edit form / Page
        // 4- SaveEdit : Edit / Update to DB

        // Dilemmas : 
        // 1- UX : Dept Id -> business : Department
        // -> Department Name
        // -> Department is already in DB

        // VD - VB - View Model ...
        // ViewModel : Emp - List of Department
        // 1-Naming 2-Sources  3-Destinations  4-Mapping

        // Delete : LifeCycle :
        // 1- UX : for each record - Delete
        // 2- Delete Action : open delete Page (alert)
        // 3- View : alert Page 
        // 4- ConfirmDelete : Delete from DB

        // Tag Helper : 
        // life cycle of Add (Emp) - Tag Helper - capabilities
        // 1- UX : INdex >> New 
        // 2- Add : open add form
        // 3- Add View(form) (empty)
        // 4- SaveAdd >> save to DB 

        // UX : dept Id -> drop down list of depts 
        // Clean - stop exception .. 
        // Emp - Dept ->   
        // viewData - ViewBag - ViewModel(Recommended)

        // UX : Open form  : 
        // options -- Select department -- 
    }
}
