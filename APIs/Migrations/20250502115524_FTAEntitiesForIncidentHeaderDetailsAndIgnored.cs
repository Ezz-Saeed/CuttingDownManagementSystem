using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class FTAEntitiesForIncidentHeaderDetailsAndIgnored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuttingDownHeaders",
                columns: table => new
                {
                    CuttingDownKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttingDownIncidentId = table.Column<int>(type: "int", nullable: false),
                    ChannelKey = table.Column<int>(type: "int", nullable: false),
                    CuttingDownProblemTypeKey = table.Column<int>(type: "int", nullable: false),
                    ActualCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SynchCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SynchUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateSystemUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateSystemUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownHeaders", x => x.CuttingDownKey);
                    table.ForeignKey(
                        name: "FK_CuttingDownHeaders_Channels_ChannelKey",
                        column: x => x.ChannelKey,
                        principalTable: "Channels",
                        principalColumn: "ChannelKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingDownHeaders_ProblemTypes_CuttingDownProblemTypeKey",
                        column: x => x.CuttingDownProblemTypeKey,
                        principalTable: "ProblemTypes",
                        principalColumn: "ProblemTypeKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuttingDownIgnored",
                columns: table => new
                {
                    CuttingDownIncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "CuttingDownDetail",
                columns: table => new
                {
                    CuttingDownDetailKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttingDownKey = table.Column<int>(type: "int", nullable: false),
                    NetworkElementKey = table.Column<int>(type: "int", nullable: false),
                    ActualCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImpactedCustomers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownDetail", x => x.CuttingDownDetailKey);
                    table.ForeignKey(
                        name: "FK_CuttingDownDetail_CuttingDownHeaders_CuttingDownKey",
                        column: x => x.CuttingDownKey,
                        principalTable: "CuttingDownHeaders",
                        principalColumn: "CuttingDownKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownDetail_CuttingDownKey",
                table: "CuttingDownDetail",
                column: "CuttingDownKey");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownHeaders_ChannelKey",
                table: "CuttingDownHeaders",
                column: "ChannelKey");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownHeaders_CuttingDownProblemTypeKey",
                table: "CuttingDownHeaders",
                column: "CuttingDownProblemTypeKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttingDownDetail");

            migrationBuilder.DropTable(
                name: "CuttingDownIgnored");

            migrationBuilder.DropTable(
                name: "CuttingDownHeaders");
        }
    }
}
