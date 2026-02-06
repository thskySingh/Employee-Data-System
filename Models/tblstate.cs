using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblstate
    {
        [Key]
        public int stateid { get; set; }
        public int countryid { get; set; }
        public string statename { get; set; }
    }
}
