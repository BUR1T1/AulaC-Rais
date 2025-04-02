using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaAula.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaisTxt",
                table: "pivetes",
                newName: "problema");

            migrationBuilder.AddColumn<int>(
                name: "idade",
                table: "pivetes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idade",
                table: "pivetes");

            migrationBuilder.RenameColumn(
                name: "problema",
                table: "pivetes",
                newName: "MaisTxt");
        }
    }
}
