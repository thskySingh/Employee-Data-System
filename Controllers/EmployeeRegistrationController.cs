using EmployeeForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeForm.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        public readonly DatabaseContext _db;
        public EmployeeRegistrationController(DatabaseContext context)
        {
            _db = context;
        }

        public IActionResult AddEmployee(int id = 0)
        {
            ViewBag.BT = "Submit";
            EmployeeAndCollection obj = new EmployeeAndCollection();
            obj.lstcountry = _db.tblcountries.ToList();
            obj.lstgender = _db.tblgenders.ToList();
            var Hdata = _db.tblhobbies.ToList();
            obj.lsthobby1 = Hdata.Select(x => new tblhobby1
            {
                hobbyid = x.hobbyid,
                hobbyname = x.hobbyname,
                ischecked = false
            }).ToList();

            if (id > 0)
            {
                var data = (from E in _db.tblemployees where E.empid == id select E).ToList();
                obj.empid = data[0].empid;
                obj.name = data[0].name;
                obj.age = data[0].age;
                obj.country = data[0].country;
                obj.state = data[0].state;
                obj.city = data[0].city;
                obj.gender = data[0].gender;
                string[] arr = data[0].hobbies.Split(',');
                foreach (var a in obj.lsthobby1)
                {
                    foreach (var b in arr)
                    {
                        if (a.hobbyname == b)
                        {
                            a.ischecked = true;
                        }
                    }
                }


                ViewBag.BT = "Update";
            }

            obj.lststate = (from S in _db.tblstates where S.countryid == obj.country select S).ToList();
            obj.lstcity = (from C in _db.tblcities where C.stateid == obj.state select C).ToList();
            return View(obj);
        }


        [HttpPost]
        public IActionResult AddEmployee(EmployeeAndCollection _eac)
        {
            string kk = "";
            foreach (var a in _eac.lsthobby1)
            {
                if (a.ischecked == true)
                {
                    kk += a.hobbyname + ",";
                }
            }
            kk = kk.TrimEnd(',');


            tblemployee _emp = new tblemployee();
            _emp.empid = _eac.empid;
            _emp.name = _eac.name;
            _emp.age = _eac.age;
            _emp.country = _eac.country;
            _emp.state = _eac.state;
            _emp.city = _eac.city;
            _emp.gender = _eac.gender;
            _emp.hobbies = kk;

            if (_emp.empid > 0)
            {
                _db.Entry(_emp).State = EntityState.Modified;
            }
            else
            {
                _db.tblemployees.Add(_emp);
            }

            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public IActionResult DeleteEmployee(int id = 0)
        {
            var data = _db.tblemployees.Find(id);
            _db.tblemployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public IActionResult ShowEmployee()
        {
            var data = (from E in _db.tblemployees
                        join C in _db.tblcountries on E.country equals C.countryid
                        join S in _db.tblstates on E.state equals S.stateid
                        join T in _db.tblcities on E.city equals T.cityid
                        join G in _db.tblgenders on E.gender equals G.genderid
                        select new EmployeeJoin
                        {
                            empid = E.empid,
                            name = E.name,
                            age = E.age,
                            country = C.countryname,
                            state = S.statename,
                            city = T.cityname,
                            gender = G.gendername,
                            hobbies = E.hobbies
                        }).ToList();
            return View(data);
        }

        [HttpGet]
        public JsonResult GetState(int A = 0)
        {
            var data = (from S in _db.tblstates where S.countryid == A select S).ToList();
            return Json(data);
        }

        [HttpGet]
        public JsonResult GetCity(int A = 0)
        {
            var data = (from C in _db.tblcities where C.stateid == A select C).ToList();
            return Json(data);
        }

    }
}
