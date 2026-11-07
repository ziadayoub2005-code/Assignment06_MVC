using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCGiza02.Models;

namespace MVCGiza02.Controllers
{
    // catch req - get req !!
    // handle logic
    // send data to view 

    // object > Index (object member)
    // http > stateless !
    public class HomeController : Controller
    {
        // URL Path :
        // /Home/Index 

        // class to be controller :
        // 1- end with Controller
        // 2- inherit from Controller (ControllerBase)
        // viewdata/viewbag/tempdata > Controller

        // Index : 
        // 1- public
        // 2- non static
        // 3- not overloaded

        // function : 
        // reusable container for logic
        // business !!
        // send data to view
        // return : int,string,double,....
        // special return >> Action 
        // string >> ContentResult
        // view >> ViewResult
        // JSon >> JsonResult
        // file >> FileResult
        // NotFound >> NotFoundResult

        // special return types : OOP _ Generalization "
        // base class / interface
        // Data types + Satandards(IActionResult) + structure(ActionResult) !!


        // /Home/ShowMsg
        public string ShowMsg()
        {
            return "Hello World";
        }


        // level 01
        // /Home/ShowMsg02
        public ContentResult ShowMsg2()
        {
            // Complex data type !
            // decalre
            ContentResult result = new ContentResult();
            // initial
            result.Content = "Hello World";
            // return
            return result;
        }

        // action : send data to view :
        // MVC one way binding !!

        // level 02
        // /Home/ShowView
        public ViewResult ShowView()
        {
            // declare
            ViewResult result = new ViewResult();
            // initial
            result.ViewName = "View1";
            // return
            return result;
        }

        // level 03 

        // reuasable : View !!
        //public ViewResult view(string ViewName)
        //{
        //    // declare
        //    ViewResult result = new ViewResult();
        //    // initial
        //    result.ViewName = ViewName;
        //    // return
        //    return result;
        //}


        // 1- OOP : Generalization : base class(ActionResult) / interface(IActionResult)
        // 2- DRY : Don't Repeat Yourself - Helper method

        // /Home/ShowMix?id=2
        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 1)
            {
                return View("View1");
            }
            else
            {
                return Content("Hello World");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void Test()
        {
            // runtime !!

            dynamic x = 1;
            dynamic y = new Employee();
            dynamic Z ;
            dynamic a = x + y;

        }

        // Clarify : 
        // Views : GetAll / GetByID ... 
        // Views : Razor Pages : Html + get C#  
        // Razor Syntax 

        // Seed data ...

        // Req : 
        // View : GetAll(Departments)
        // Model - Controller - View ?!!!
        // 1- model layer ..
        // models + BL on this models
        // 1-1 models (class specs document) - Classes as a code 
        // 1-2 Map this model to DB 
        // 1-2-0 Environment (EFCore.SQLServer-EFCore.tools)
        // 1-2-1 Connect to DB 
        // 1-2-1-1 represent Connection
        // 1-2-1-1-1 Connection Data
        // 1-2-1-1-2 Mapping (Fluent API - Clean)
        // 1-2-1-1-3 Execute Mapping
        // 1-2 BL on this models

        // Controller :
        // catch req - get data from model - send data to view
        // Action

        // View 


        // GetEmpById > Specific Emp Data 
        // Model : models - BL 
        // Controller : BL on Emp
    }
}

