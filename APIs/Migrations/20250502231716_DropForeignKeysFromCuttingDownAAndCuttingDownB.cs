using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class DropForeignKeysFromCuttingDownAAndCuttingDownB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UpdateSystemUserID",
                table: "CuttingDownHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateSystemUserID",
                table: "CuttingDownHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
