using System.ComponentModel.DataAnnotations;

namespace ST10382076_API_EF_PROGPOE2.Models
{
    public class tblRole
    {
        [Key] //ses the primary key
        public int RoleID { get; set; }

        [Required] //not null
        [StringLength(100)]
        public string RoleName { get; set; }

        // Navigation property
        public ICollection<tblUser> Users { get; set; } //allows developer to call a list of all tblUser properties
    }
}
