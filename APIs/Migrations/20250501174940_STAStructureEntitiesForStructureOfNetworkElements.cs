using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class STAStructureEntitiesForStructureOfNetworkElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    GovernrateKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernrateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.GovernrateKey);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernrateKey = table.Column<int>(type: "int", nullable: false),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorKey);
                    table.ForeignKey(
                        name: "FK_Sector_Governorates_GovernrateKey",
                        column: x => x.GovernrateKey,
                        principalTable: "Governorates",
                        principalColumn: "GovernrateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorKey = table.Column<int>(type: "int", nullable: false),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZoneKey);
                    table.ForeignKey(
                        name: "FK_Zone_Sector_SectorKey",
                        column: x => x.SectorKey,
                        principalTable: "Sector",
                        principalColumn: "SectorKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneKey = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityKey);
                    table.ForeignKey(
                        name: "FK_City_Zone_ZoneKey",
                        column: x => x.ZoneKey,
                        principalTable: "Zone",
                        principalColumn: "ZoneKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityKey = table.Column<int>(type: "int", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationKey);
                    table.ForeignKey(
                        name: "FK_Station_City_CityKey",
                        column: x => x.CityKey,
                        principalTable: "City",
                        principalColumn: "CityKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tower",
                columns: table => new
                {
                    TowerKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationKey = table.Column<int>(type: "int", nullable: false),
                    TowerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tower", x => x.TowerKey);
                    table.ForeignKey(
                        name: "FK_Tower_Station_StationKey",
                        column: x => x.StationKey,
                        principalTable: "Station",
                        principalColumn: "StationKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cabin",
                columns: table => new
                {
                    CabinKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TowerKey = table.Column<int>(type: "int", nullable: false),
                    CabinName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabin", x => x.CabinKey);
                    table.ForeignKey(
                        name: "FK_Cabin_Tower_TowerKey",
                        column: x => x.TowerKey,
                        principalTable: "Tower",
                        principalColumn: "TowerKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cable",
                columns: table => new
                {
                    CableKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinKey = table.Column<int>(type: "int", nullable: false),
                    CableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cable", x => x.CableKey);
                    table.ForeignKey(
                        name: "FK_Cable_Cabin_CabinKey",
                        column: x => x.CabinKey,
                        principalTable: "Cabin",
                        principalColumn: "CabinKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    BlockKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableKey = table.Column<int>(type: "int", nullable: false),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.BlockKey);
                    table.ForeignKey(
                        name: "FK_Block_Cable_CableKey",
                        column: x => x.CableKey,
                        principalTable: "Cable",
                        principalColumn: "CableKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockKey = table.Column<int>(type: "int", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingKey);
                    table.ForeignKey(
                        name: "FK_Building_Block_BlockKey",
                        column: x => x.BlockKey,
                        principalTable: "Block",
                        principalColumn: "BlockKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    FlatKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.FlatKey);
                    table.ForeignKey(
                        name: "FK_Flat_Building_BuildingKey",
                        column: x => x.BuildingKey,
                        principalTable: "Building",
                        principalColumn: "BuildingKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    SubscriptionKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatKey = table.Column<int>(type: "int", nullable: false),
                    BuildingKey = table.Column<int>(type: "int", nullable: false),
                    MeterKey = table.Column<int>(type: "int", nullable: true),
                    PaletKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.SubscriptionKey);
                    table.ForeignKey(
                        name: "FK_Subscription_Building_BuildingKey",
                        column: x => x.BuildingKey,
                        principalTable: "Building",
                        principalColumn: "BuildingKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_Flat_FlatKey",
                        column: x => x.FlatKey,
                        principalTable: "Flat",
                        principalColumn: "FlatKey",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_CableKey",
                table: "Block",
                column: "CableKey");

            migrationBuilder.CreateIndex(
                name: "IX_Building_BlockKey",
                table: "Building",
                column: "BlockKey");

            migrationBuilder.CreateIndex(
                name: "IX_Cabin_TowerKey",
                table: "Cabin",
                column: "TowerKey");

            migrationBuilder.CreateIndex(
                name: "IX_Cable_CabinKey",
                table: "Cable",
                column: "CabinKey");

            migrationBuilder.CreateIndex(
                name: "IX_City_ZoneKey",
                table: "City",
                column: "ZoneKey");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_BuildingKey",
                table: "Flat",
                column: "BuildingKey");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_GovernrateKey",
                table: "Sector",
                column: "GovernrateKey");

            migrationBuilder.CreateIndex(
                name: "IX_Station_CityKey",
                table: "Station",
                column: "CityKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_BuildingKey",
                table: "Subscription",
                column: "BuildingKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_FlatKey",
                table: "Subscription",
                column: "FlatKey");

            migrationBuilder.CreateIndex(
                name: "IX_Tower_StationKey",
                table: "Tower",
                column: "StationKey");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_SectorKey",
                table: "Zone",
                column: "SectorKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Cable");

            migrationBuilder.DropTable(
                name: "Cabin");

            migrationBuilder.DropTable(
                name: "Tower");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
