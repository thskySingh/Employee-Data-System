using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblgender
    {
        [Key]
        public int genderid { get; set; }
        public string gendername { get; set; }
    }
}
