using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblcountry
    {
        [Key]
        public int countryid { get; set; }
        public string countryname { get; set; }
    }
}
