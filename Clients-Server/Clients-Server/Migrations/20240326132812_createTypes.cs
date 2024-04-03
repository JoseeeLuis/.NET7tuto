using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients_Server.Migrations
{
    /// <inheritdoc />
    public partial class createTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prueba",
                table: "Workers");

            migrationBuilder.AlterColumn<string>(
                name: "SeniorityTypeCode",
                table: "WorkersDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentTypeCode",
                table: "WorkersDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    DepartamentTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.DepartamentTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Seniorities",
                columns: table => new
                {
                    SeniorityTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniorities", x => x.SeniorityTypeCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkersDetails_DepartamentTypeCode",
                table: "WorkersDetails",
                column: "DepartamentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_WorkersDetails_SeniorityTypeCode",
                table: "WorkersDetails",
                column: "SeniorityTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDetails_Departaments_DepartamentTypeCode",
                table: "WorkersDetails",
                column: "DepartamentTypeCode",
                principalTable: "Departaments",
                principalColumn: "DepartamentTypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDetails_Seniorities_SeniorityTypeCode",
                table: "WorkersDetails",
                column: "SeniorityTypeCode",
                principalTable: "Seniorities",
                principalColumn: "SeniorityTypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDetails_Departaments_DepartamentTypeCode",
                table: "WorkersDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDetails_Seniorities_SeniorityTypeCode",
                table: "WorkersDetails");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "Seniorities");

            migrationBuilder.DropIndex(
                name: "IX_WorkersDetails_DepartamentTypeCode",
                table: "WorkersDetails");

            migrationBuilder.DropIndex(
                name: "IX_WorkersDetails_SeniorityTypeCode",
                table: "WorkersDetails");

            migrationBuilder.AlterColumn<string>(
                name: "SeniorityTypeCode",
                table: "WorkersDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentTypeCode",
                table: "WorkersDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Prueba",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
