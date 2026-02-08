using EmployeeForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeForm.Controllers
{
    public class Home1 : Controller 
    {
        public readonly DatabaseContext _db;
        public Home1(DatabaseContext context)
        {
            _db = context;
        }
        public IActionResult AddHome()
        {
            var data = (from E in _db.tblemployees
                        join C in _db.tblcountries on E.country equals C.countryid
                        join S in _db.tblstates on E.state equals S.stateid
                        join T in _db.tblcities on E.city equals T.cityid
                        join G in _db.tblgenders on E.gender equals G.genderid
                        where E.empid == HttpContext.Session.GetInt32("SessionId")
            select new EmployeeJoin
                        {
                            empid = E.empid,
                            name = E.name,
                            age = E.age,
                            country = C.countryname,
                            state = S.statename,
                            city = T.cityname,
                            gender = G.gendername,
                            hobbies = E.hobbies,
                            email = E.email,
                            password = E.password,
                            image = E.image
                        }).ToList();
            return View(data);
        }
    }
}
