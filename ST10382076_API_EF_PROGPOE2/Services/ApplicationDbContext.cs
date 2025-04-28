using Microsoft.EntityFrameworkCore;
using ST10382076_API_EF_PROGPOE2.Models;

namespace ST10382076_API_EF_PROGPOE2.Services
{
    public class ApplicationDbContext: DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<tblUser> Users { get; set; }
            public DbSet<tblRole> Roles { get; set; }
            public DbSet<tblProduct> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Seeding tblRole
                modelBuilder.Entity<tblRole>().HasData(
                    new tblRole { RoleID = 1, RoleName = "Employee" },
                    new tblRole { RoleID = 2, RoleName = "Farmer" },
                    new tblRole { RoleID = 3, RoleName = "Customer" }
                );

                // Seeding tblUser
                modelBuilder.Entity<tblUser>().HasData(
                    new tblUser
                    {
                        UserID = 1,
                        RoleID = 1, // Employee
                        UserName = "Emily",
                        UserSurname = "Greenfield",
                        UserBio = "Specialist in sustainable farming technologies.",
                        UserProfileImage = "emily_profile.jpg",
                        UserImageUpload = "emily_upload.jpg",
                        UserProvince = "Western Cape",
                        UserCity = "Cape Town",
                        UserLanguage = "English",
                        UserSkills = "Solar Installation, Customer Support",
                        UserExpertiseLevel = "Expert",
                        UserPreviousCollaborators = "AgriSolar Ltd."
                    },
                    new tblUser
                    {
                        UserID = 2,
                        RoleID = 2, // Farmer
                        UserName = "John",
                        UserSurname = "Nkosi",
                        UserBio = "Experienced maize and wheat farmer transitioning to renewable energy.",
                        UserProfileImage = "john_profile.jpg",
                        UserImageUpload = "john_upload.jpg",
                        UserProvince = "KwaZulu-Natal",
                        UserCity = "Pietermaritzburg",
                        UserLanguage = "Zulu",
                        UserSkills = "Irrigation Management, Soil Health",
                        UserExpertiseLevel = "Intermediate",
                        UserPreviousCollaborators = "GreenEarth NGO"
                    },
                    new tblUser
                    {
                        UserID = 3,
                        RoleID = 3, // Customer
                        UserName = "Sara",
                        UserSurname = "Mthembu",
                        UserBio = "Purchasing green tech solutions for her family's farm.",
                        UserProfileImage = "sara_profile.jpg",
                        UserImageUpload = "sara_upload.jpg",
                        UserProvince = "Limpopo",
                        UserCity = "Polokwane",
                        UserLanguage = "English",
                        UserSkills = "Farm Administration",
                        UserExpertiseLevel = "Beginner",
                        UserPreviousCollaborators = ""
                    }
                );

                // Seeding tblProduct
                modelBuilder.Entity<tblProduct>().HasData(
                    new tblProduct
                    {
                        ProductID = 1,
                        ProductName = "Solar Powered Irrigation Pump",
                        ProductDescription = "High-efficiency solar irrigation system for medium-sized farms.",
                        ProductPrice = 35000.00,
                        ProductImage = "solar_pump.jpg",
                        ProductDateTimeAdded = new DateTime(2025, 4, 28),
                        ProductType = "Solar",
                        UserID = 1 // Added by Employee Emily
                    },
                    new tblProduct
                    {
                        ProductID = 2,
                        ProductName = "Wind Turbine for Farms",
                        ProductDescription = "Small-scale wind turbine optimized for rural farm energy generation.",
                        ProductPrice = 50000.00,
                        ProductImage = "wind_turbine.jpg",
                        ProductDateTimeAdded = new DateTime(2025, 4, 27),
                        ProductType = "Wind",
                        UserID = 1
                    },
                    new tblProduct
                    {
                        ProductID = 3,
                        ProductName = "Biogas Digester Kit",
                        ProductDescription = "Complete biogas system suitable for agricultural waste-to-energy conversion.",
                        ProductPrice = 25000.00,
                        ProductImage = "biogas_kit.jpg",
                        ProductDateTimeAdded = new DateTime(2025, 4, 21),
                        ProductType = "Biogas",
                        UserID = 1
                    }
                );
            }
        
    }
}
