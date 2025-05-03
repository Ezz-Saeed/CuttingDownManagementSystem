using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class NewCuttingDownIgnoredKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuttingDownIgnored",
                table: "CuttingDownIgnored");

            migrationBuilder.AlterColumn<int>(
                name: "CuttingDownIncidentId",
                table: "CuttingDownIgnored",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CuttingDownIgnoredKey",
                table: "CuttingDownIgnored",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuttingDownIgnored",
                table: "CuttingDownIgnored",
                column: "CuttingDownIgnoredKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuttingDownIgnored",
                table: "CuttingDownIgnored");

            migrationBuilder.DropColumn(
                name: "CuttingDownIgnoredKey",
                table: "CuttingDownIgnored");

            migrationBuilder.AlterColumn<int>(
                name: "CuttingDownIncidentId",
                table: "CuttingDownIgnored",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuttingDownIgnored",
                table: "CuttingDownIgnored",
                column: "CuttingDownIncidentId");
        }
    }
}
