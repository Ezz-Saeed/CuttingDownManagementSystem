using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class IsProcessedToCuttingDown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CableKey",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "CabinKey",
                table: "CuttingDownA");

            migrationBuilder.AddColumn<int>(
                name: "CuttingDownCableKey",
                table: "CuttingDownB",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuttingDownCableName",
                table: "CuttingDownB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "CuttingDownB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CuttingDownCabinKey",
                table: "CuttingDownA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuttingDownCabinName",
                table: "CuttingDownA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "CuttingDownA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownB_CuttingDownCableKey",
                table: "CuttingDownB",
                column: "CuttingDownCableKey");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownA_CuttingDownCabinKey",
                table: "CuttingDownA",
                column: "CuttingDownCabinKey");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingDownA_Cabin_CuttingDownCabinKey",
                table: "CuttingDownA",
                column: "CuttingDownCabinKey",
                principalTable: "Cabin",
                principalColumn: "CabinKey");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingDownB_Cable_CuttingDownCableKey",
                table: "CuttingDownB",
                column: "CuttingDownCableKey",
                principalTable: "Cable",
                principalColumn: "CableKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingDownA_Cabin_CuttingDownCabinKey",
                table: "CuttingDownA");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingDownB_Cable_CuttingDownCableKey",
                table: "CuttingDownB");

            migrationBuilder.DropIndex(
                name: "IX_CuttingDownB_CuttingDownCableKey",
                table: "CuttingDownB");

            migrationBuilder.DropIndex(
                name: "IX_CuttingDownA_CuttingDownCabinKey",
                table: "CuttingDownA");

            migrationBuilder.DropColumn(
                name: "CuttingDownCableKey",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "CuttingDownCableName",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "CuttingDownCabinKey",
                table: "CuttingDownA");

            migrationBuilder.DropColumn(
                name: "CuttingDownCabinName",
                table: "CuttingDownA");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "CuttingDownA");

            migrationBuilder.AddColumn<int>(
                name: "CableKey",
                table: "CuttingDownB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabinKey",
                table: "CuttingDownA",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
