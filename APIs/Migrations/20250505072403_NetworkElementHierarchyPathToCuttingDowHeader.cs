using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class NetworkElementHierarchyPathToCuttingDowHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HierarchyPathKey",
                table: "CuttingDownHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownHeaders_HierarchyPathKey",
                table: "CuttingDownHeaders",
                column: "HierarchyPathKey");

            migrationBuilder.AddForeignKey(
                name: "FK_CuttingDownHeaders_NetworkElementHierarchyPath_HierarchyPathKey",
                table: "CuttingDownHeaders",
                column: "HierarchyPathKey",
                principalTable: "NetworkElementHierarchyPath",
                principalColumn: "NetworkElementHierarchyPathKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuttingDownHeaders_NetworkElementHierarchyPath_HierarchyPathKey",
                table: "CuttingDownHeaders");

            migrationBuilder.DropIndex(
                name: "IX_CuttingDownHeaders_HierarchyPathKey",
                table: "CuttingDownHeaders");

            migrationBuilder.DropColumn(
                name: "HierarchyPathKey",
                table: "CuttingDownHeaders");
        }
    }
}
