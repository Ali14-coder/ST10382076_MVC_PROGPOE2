using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ST10382076_API_EF_PROGPOE2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImageUpload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserExpertiseLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPreviousCollaborators = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Employee" },
                    { 2, "Farmer" },
                    { 3, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "RoleID", "UserBio", "UserCity", "UserExpertiseLevel", "UserImageUpload", "UserLanguage", "UserName", "UserPreviousCollaborators", "UserProfileImage", "UserProvince", "UserSkills", "UserSurname" },
                values: new object[,]
                {
                    { 1, 1, "Specialist in sustainable farming technologies.", "Cape Town", "Expert", "emily_upload.jpg", "English", "Emily", "AgriSolar Ltd.", "emily_profile.jpg", "Western Cape", "Solar Installation, Customer Support", "Greenfield" },
                    { 2, 2, "Experienced maize and wheat farmer transitioning to renewable energy.", "Pietermaritzburg", "Intermediate", "john_upload.jpg", "Zulu", "John", "GreenEarth NGO", "john_profile.jpg", "KwaZulu-Natal", "Irrigation Management, Soil Health", "Nkosi" },
                    { 3, 3, "Purchasing green tech solutions for her family's farm.", "Polokwane", "Beginner", "sara_upload.jpg", "English", "Sara", "", "sara_profile.jpg", "Limpopo", "Farm Administration", "Mthembu" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductDateTimeAdded", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductType", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 28, 14, 43, 22, 105, DateTimeKind.Utc).AddTicks(2011), "High-efficiency solar irrigation system for medium-sized farms.", "solar_pump.jpg", "Solar Powered Irrigation Pump", 35000.0, "Solar", 1 },
                    { 2, new DateTime(2025, 4, 28, 14, 43, 22, 105, DateTimeKind.Utc).AddTicks(2799), "Small-scale wind turbine optimized for rural farm energy generation.", "wind_turbine.jpg", "Wind Turbine for Farms", 50000.0, "Wind", 1 },
                    { 3, new DateTime(2025, 4, 28, 14, 43, 22, 105, DateTimeKind.Utc).AddTicks(2801), "Complete biogas system suitable for agricultural waste-to-energy conversion.", "biogas_kit.jpg", "Biogas Digester Kit", 25000.0, "Biogas", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserID",
                table: "Products",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
