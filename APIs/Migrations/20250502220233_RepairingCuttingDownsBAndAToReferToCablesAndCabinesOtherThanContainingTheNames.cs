using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class RepairingCuttingDownsBAndAToReferToCablesAndCabinesOtherThanContainingTheNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuttingDownCableName",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "CuttingDownCabinName",
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

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownB_CableKey",
                table: "CuttingDownB",
                column: "CableKey");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownA_CabinKey",
                table: "CuttingDownA",
                column: "CabinKey");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingDownA_Cabin_CabinKey",
                table: "CuttingDownA",
                column: "CabinKey",
                principalTable: "Cabin",
                principalColumn: "CabinKey",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingDownB_Cable_CableKey",
                table: "CuttingDownB",
                column: "CableKey",
                principalTable: "Cable",
                principalColumn: "CableKey",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingDownA_Cabin_CabinKey",
                table: "CuttingDownA");

            migrationBuilder.DropForeignKey(
                name: "FK_CuttingDownB_Cable_CableKey",
                table: "CuttingDownB");

            migrationBuilder.DropIndex(
                name: "IX_CuttingDownB_CableKey",
                table: "CuttingDownB");

            migrationBuilder.DropIndex(
                name: "IX_CuttingDownA_CabinKey",
                table: "CuttingDownA");

            migrationBuilder.DropColumn(
                name: "CableKey",
                table: "CuttingDownB");

            migrationBuilder.DropColumn(
                name: "CabinKey",
                table: "CuttingDownA");

            migrationBuilder.AddColumn<string>(
                name: "CuttingDownCableName",
                table: "CuttingDownB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CuttingDownCabinName",
                table: "CuttingDownA",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
