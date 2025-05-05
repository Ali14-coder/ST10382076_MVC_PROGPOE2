using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace ST10382076_API_EF_PROGPOE2.Models
{
    public class tblUser : IdentityUser
    {
        [Key] //primary key
        public int UserID { get; set; }

        [Required]
        [ForeignKey("tblRole")] //foreign key
        public int RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserSurname { get; set; }

        [Required]
        [StringLength(100)]
        public string UserEmail { get; set; }

        //all null fields
        public string UserBio { get; set; }
        public string UserProfileImage { get; set; }
        public string UserImageUpload { get; set; }
        public string UserProvince { get; set; }
        public string UserCity { get; set; }
        public string UserLanguage { get; set; }
        public string UserSkills { get; set; }
        public string UserExpertiseLevel { get; set; }
        public string UserPreviousCollaborators { get; set; }

        // Navigation properties
        public tblRole tblRole { get; set; } //instance for tblRole
        public ICollection<tblProduct> Products { get; set; }  //allows developer to call a list of all tblProduct properties
    }
}
