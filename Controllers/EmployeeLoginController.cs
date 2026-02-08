using Microsoft.AspNetCore.Mvc;
using EmployeeForm.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeForm.Controllers
{
    public class EmployeeLoginController : Controller
    {
        public readonly DatabaseContext _db;

        public EmployeeLoginController(DatabaseContext context)
        {
            _db = context; 
        }

        public IActionResult AddLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLogin(tblemployee _emp)
        {
            var data = (from E in _db.tblemployees
                        where E.email == _emp.email
                        && E.password == _emp.password
                        select E).ToList();

            if(data.Count > 0)
            {
                HttpContext.Session.SetInt32("SessionId", data[0].empid);
                return RedirectToAction("AddHome", "Home1");
            }
            else
            {
                ViewBag.msg = "Login Failed!!";
                return View();
            }
            
        }
    }
}
