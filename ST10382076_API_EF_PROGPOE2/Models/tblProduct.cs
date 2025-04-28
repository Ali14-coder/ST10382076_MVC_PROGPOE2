using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ST10382076_API_EF_PROGPOE2.Models
{
    public class tblProduct
    {
            [Key]
            public int ProductID { get; set; }

            [Required]
            [StringLength(100)]
            public string ProductName { get; set; }

            public string ProductDescription { get; set; }

            [Required]
            public double ProductPrice { get; set; }

            public string ProductImage { get; set; }

            [Required]
            public DateTime ProductDateTimeAdded { get; set; }

            public string ProductType { get; set; }

            [Required]
            [ForeignKey("tblUser")] //foreign key
            public int UserID { get; set; }

            // Navigation property
            public tblUser tblUser { get; set; }  //allows developer to call a list of all tblUser properties

    }
}
