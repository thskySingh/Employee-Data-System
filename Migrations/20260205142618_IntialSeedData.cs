using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeForm.Migrations
{
    /// <inheritdoc />
    public partial class IntialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcities",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateid = table.Column<int>(type: "int", nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcities", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "tblcountries",
                columns: table => new
                {
                    countryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcountries", x => x.countryid);
                });

            migrationBuilder.CreateTable(
                name: "tblemployees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hobbies = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblemployees", x => x.empid);
                });

            migrationBuilder.CreateTable(
                name: "tblgenders",
                columns: table => new
                {
                    genderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gendername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblgenders", x => x.genderid);
                });

            migrationBuilder.CreateTable(
                name: "tblhobbies",
                columns: table => new
                {
                    hobbyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hobbyname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblhobbies", x => x.hobbyid);
                });

            migrationBuilder.CreateTable(
                name: "tblstates",
                columns: table => new
                {
                    stateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(type: "int", nullable: false),
                    statename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblstates", x => x.stateid);
                });

            migrationBuilder.InsertData(
                table: "tblcities",
                columns: new[] { "cityid", "cityname", "stateid" },
                values: new object[,]
                {
                    { 1, "Ahmedabad", 1 },
                    { 2, "Surat", 1 },
                    { 3, "Mumbai", 2 },
                    { 4, "Pune", 2 },
                    { 5, "Lahore", 3 },
                    { 6, "Multan", 3 },
                    { 7, "Karachi", 4 },
                    { 8, "Hyderabad", 4 }
                });

            migrationBuilder.InsertData(
                table: "tblcountries",
                columns: new[] { "countryid", "countryname" },
                values: new object[,]
                {
                    { 1, "India" },
                    { 2, "Pakistan" }
                });

            migrationBuilder.InsertData(
                table: "tblgenders",
                columns: new[] { "genderid", "gendername" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Transgender" }
                });

            migrationBuilder.InsertData(
                table: "tblhobbies",
                columns: new[] { "hobbyid", "hobbyname" },
                values: new object[,]
                {
                    { 1, "Cricket" },
                    { 2, "Football" },
                    { 3, "Reading" },
                    { 4, "Music" },
                    { 5, "Traveling" },
                    { 6, "Gaming" },
                    { 7, "Cooking" },
                    { 8, "Photography" }
                });

            migrationBuilder.InsertData(
                table: "tblstates",
                columns: new[] { "stateid", "countryid", "statename" },
                values: new object[,]
                {
                    { 1, 1, "Gujarat" },
                    { 2, 1, "Maharashtra" },
                    { 3, 2, "Punjab" },
                    { 4, 2, "Sindh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcities");

            migrationBuilder.DropTable(
                name: "tblcountries");

            migrationBuilder.DropTable(
                name: "tblemployees");

            migrationBuilder.DropTable(
                name: "tblgenders");

            migrationBuilder.DropTable(
                name: "tblhobbies");

            migrationBuilder.DropTable(
                name: "tblstates");
        }
    }
}
