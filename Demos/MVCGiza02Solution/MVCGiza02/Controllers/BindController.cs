using Microsoft.AspNetCore.Mvc;
using MVCGiza02.Models;

namespace MVCGiza02.Controllers
{
    public class BindController : Controller
    {
        // Map Data ! 
        // Action Parameters take values of req (Model Bind)

        // Data in req : BE (Business Logic)
        // Bind Data 
        // Parameters take his values (model bind)

        // Constraints : 
        // Req : keys ansd values
        // 1- Keys the same as parameters

        // query string / Form data / Routing values

        // 1- Form data
        // 2- Routin Values
        // 3- query string
        // 4- default values

        // /Bind/Test?Name=ali&Age=22 
        // /Bind/Test?Name=ali&Age=22&color=red
        // /Bind/Test?Name=ali

        // id : special Parameter - by default - Identify 
        // Action : get specific Product/Emp/... -> id
        // /Bind/Test/2 > /Controller/Action/id

        // /Bind/Test/2?Name=ali&Age=22 
        // /Bind/Test/2?Name=ali&Age=22&id=5
        public IActionResult Test(string Name, int Age,int id)
        {
            return Content("OK");
        }

        // Add Product : 7 Properties from User : 
        // Map 7 Properties 
        // Map Complex object not Primitive

        // Constraints : 
        // Keys is the name attributes ..
        //1- Keys the same as Object(model/viewmodel) Properties

        // /Bind/Test02?ID=4&NAme=SD&mgrname=ali

        public IActionResult Test02(Department Dept)
        {
            return Content("OK");
        }
    }
}
