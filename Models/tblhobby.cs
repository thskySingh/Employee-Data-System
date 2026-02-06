using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblhobby
    {
        [Key]
        public int hobbyid { get; set; }
        public string hobbyname { get; set; }
        public bool ischecked = true;
    }
}
