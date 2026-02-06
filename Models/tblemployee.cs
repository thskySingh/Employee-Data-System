using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblemployee
    {
        [Key]
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int country { get; set; }
        public int state { get; set; }
        public int city { get; set; }
        public int gender { get; set; }
        public string hobbies { get; set; }
    }
}
