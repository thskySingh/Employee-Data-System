using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class EmployeeJoin
    {
        [Key]
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public string hobbies { get; set; }
    }
}
