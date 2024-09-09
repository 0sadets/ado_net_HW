using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Library.Migrations
{
    /// <inheritdoc />
    public partial class workerChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Kulumyk", "123" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Kvitka", "123" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Ivan", "132" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Petro", "123" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Socol", "123" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Andriy", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });
        }
    }
}
