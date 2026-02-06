using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblcity
    {
        [Key]
        public int cityid { get; set; }
        public int stateid { get; set; }
        public string cityname { get; set; }
    }
}
