using EmployeeForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                obj.email = data[0].email;
                obj.password = data[0].password;
                obj.image = data[0].image;

                ViewBag.BT = "Update";
            }

            obj.lststate = (from S in _db.tblstates where S.countryid == obj.country select S).ToList();
            obj.lstcity = (from C in _db.tblcities where C.stateid == obj.state select C).ToList();
            return View(obj);
        }


        [HttpPost]
        public IActionResult AddEmployee(EmployeeAndCollection _eac, IFormFile file)
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
            _emp.email = _eac.email;
            _emp.password = _eac.password;
            _emp.image = _eac.image;
            

            if (_emp.empid > 0)
            {
                if(file != null) { 
                    string FN = Path.GetFileName(file.FileName);

                    using (FileStream fs = System.IO.File.Create(Path.Combine("wwwroot/EmployeePics", FN)))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    System.IO.File.Delete(Path.Combine("wwwroot/EmployeePics", _emp.image));

                    _emp.image = FN;
                }
                _db.Entry(_emp).State = EntityState.Modified;
            }
            else
            {
                string FN = Path.GetFileName(file.FileName);

                using (FileStream fs = System.IO.File.Create(Path.Combine("wwwroot/EmployeePics", FN)))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                _emp.image = FN;

                _db.tblemployees.Add(_emp);
            }

            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public IActionResult DeleteEmployee(int id = 0)
        {
            var data = _db.tblemployees.Find(id);
            _db.tblemployees.Remove(data);
            System.IO.File.Delete(Path.Combine("wwwroot/EmployeePics", data.image));
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
                            hobbies = E.hobbies,
                            email = E.email,
                            password = E.password,
                            image = E.image
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
