using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class tblhobby1
    {
        [Key]
        public int hobbyid { get; set; }
        public string hobbyname { get; set; }
        public bool ischecked { get; set; } = true;
    }
}
