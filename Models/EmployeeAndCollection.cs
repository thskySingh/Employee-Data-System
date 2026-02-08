using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class EmployeeAndCollection
    {
        [Key]
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int country { get; set; }
        public int state { get; set; }
        public int city { get; set; }
        public int gender { get; set; }
        public int hobbies { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string image { get; set; }


        public List<tblcountry> lstcountry { get; set; }
        public List<tblstate> lststate { get; set; }
        public List<tblcity> lstcity { get; set; }
        public List<tblgender> lstgender { get; set; }
        public List<tblhobby1> lsthobby1 { get; set; }
    }
}
