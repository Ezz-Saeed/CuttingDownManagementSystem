using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class IncidentsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProblemTypes",
                columns: table => new
                {
                    ProblemTypeKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTypes", x => x.ProblemTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "CuttingDownA",
                columns: table => new
                {
                    CuttingDownIncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttingDownCabinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemTypeKey = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownA", x => x.CuttingDownIncidentId);
                    table.ForeignKey(
                        name: "FK_CuttingDownA_ProblemTypes_ProblemTypeKey",
                        column: x => x.ProblemTypeKey,
                        principalTable: "ProblemTypes",
                        principalColumn: "ProblemTypeKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuttingDownB",
                columns: table => new
                {
                    CuttingDownIncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttingDownCableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemTypeKey = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownB", x => x.CuttingDownIncidentId);
                    table.ForeignKey(
                        name: "FK_CuttingDownB_ProblemTypes_ProblemTypeKey",
                        column: x => x.ProblemTypeKey,
                        principalTable: "ProblemTypes",
                        principalColumn: "ProblemTypeKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownA_ProblemTypeKey",
                table: "CuttingDownA",
                column: "ProblemTypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownB_ProblemTypeKey",
                table: "CuttingDownB",
                column: "ProblemTypeKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttingDownA");

            migrationBuilder.DropTable(
                name: "CuttingDownB");

            migrationBuilder.DropTable(
                name: "ProblemTypes");
        }
    }
}
