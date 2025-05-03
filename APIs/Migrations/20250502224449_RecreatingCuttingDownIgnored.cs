using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class RecreatingCuttingDownIgnored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuttingDownIgnored",
                columns: table => new
                {
                    CuttingDownIncidentId = table.Column<int>(type: "int", nullable: false),
                    ActualCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SynchCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownIgnored", x => x.CuttingDownIncidentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttingDownIgnored");
        }
    }
}
