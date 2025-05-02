using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class FTAEntitiesForHierarchyOfTheNetwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ChannelKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ChannelKey);
                });

            migrationBuilder.CreateTable(
                name: "NetworkElementHierarchyPath",
                columns: table => new
                {
                    NetworkElementHierarchyPathKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkElementHierarchyPathName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkElementHierarchyPath", x => x.NetworkElementHierarchyPathKey);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserKey);
                });

            migrationBuilder.CreateTable(
                name: "NetworkElementTypes",
                columns: table => new
                {
                    NetworkElementTypeKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkElementTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentNetworkElementTypeKey = table.Column<int>(type: "int", nullable: true),
                    NetworkElementHierarchyPathKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkElementTypes", x => x.NetworkElementTypeKey);
                    table.ForeignKey(
                        name: "FK_NetworkElementTypes_NetworkElementHierarchyPath_NetworkElementHierarchyPathKey",
                        column: x => x.NetworkElementHierarchyPathKey,
                        principalTable: "NetworkElementHierarchyPath",
                        principalColumn: "NetworkElementHierarchyPathKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NetworkElementTypes_NetworkElementTypes_ParentNetworkElementTypeKey",
                        column: x => x.ParentNetworkElementTypeKey,
                        principalTable: "NetworkElementTypes",
                        principalColumn: "NetworkElementTypeKey");
                });

            migrationBuilder.CreateTable(
                name: "NetworkElement",
                columns: table => new
                {
                    NetworkElementKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkElementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetworkElementTypeKey = table.Column<int>(type: "int", nullable: false),
                    NetworkElementHierarchyPathKey = table.Column<int>(type: "int", nullable: false),
                    ParentNetworkElementKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkElement", x => x.NetworkElementKey);
                    table.ForeignKey(
                        name: "FK_NetworkElement_NetworkElementHierarchyPath_NetworkElementHierarchyPathKey",
                        column: x => x.NetworkElementHierarchyPathKey,
                        principalTable: "NetworkElementHierarchyPath",
                        principalColumn: "NetworkElementHierarchyPathKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NetworkElement_NetworkElementTypes_NetworkElementTypeKey",
                        column: x => x.NetworkElementTypeKey,
                        principalTable: "NetworkElementTypes",
                        principalColumn: "NetworkElementTypeKey",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NetworkElement_NetworkElement_ParentNetworkElementKey",
                        column: x => x.ParentNetworkElementKey,
                        principalTable: "NetworkElement",
                        principalColumn: "NetworkElementKey");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkElement_NetworkElementHierarchyPathKey",
                table: "NetworkElement",
                column: "NetworkElementHierarchyPathKey");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkElement_NetworkElementTypeKey",
                table: "NetworkElement",
                column: "NetworkElementTypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkElement_ParentNetworkElementKey",
                table: "NetworkElement",
                column: "ParentNetworkElementKey");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkElementTypes_NetworkElementHierarchyPathKey",
                table: "NetworkElementTypes",
                column: "NetworkElementHierarchyPathKey");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkElementTypes_ParentNetworkElementTypeKey",
                table: "NetworkElementTypes",
                column: "ParentNetworkElementTypeKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "NetworkElement");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "NetworkElementTypes");

            migrationBuilder.DropTable(
                name: "NetworkElementHierarchyPath");
        }
    }
}
