using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "ChannelKey", "ChannelName" },
                values: new object[,]
                {
                    { 1, "Source A" },
                    { 2, "Source B" }
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "GovernrateKey", "GovernrateName" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alex" },
                    { 3, "Giza" },
                    { 4, "Suez" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElementHierarchyPath",
                columns: new[] { "NetworkElementHierarchyPathKey", "Abbreviation", "NetworkElementHierarchyPathName" },
                values: new object[,]
                {
                    { 1, "Governrate -> Individual Subscription", "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Flat, Individual Subscription" },
                    { 2, "Governrate -> Corporate Subscription", "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Corporate Subscription" }
                });

            migrationBuilder.InsertData(
                table: "ProblemTypes",
                columns: new[] { "ProblemTypeKey", "ProblemTypeName" },
                values: new object[,]
                {
                    { 1, "حريق" },
                    { 2, "ضغط عالى" },
                    { 3, "استهلاك عالى" },
                    { 4, "مديونيه" },
                    { 5, "تلف عداد" },
                    { 6, "سرقة تيار" },
                    { 7, "امطار" },
                    { 8, "كسر ماسورة مياه" },
                    { 9, "كسر ماسورة غاز" },
                    { 10, "تحديث واحلال" },
                    { 11, "صيانه" },
                    { 12, "كابل مقطوع" },
                    { 13, "توصيل كابل" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserKey", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "test", "test" },
                    { 3, "SourceA", "SourceA" },
                    { 4, "SourceB", "SourceB" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 1, 1, "Governrate", null });

            migrationBuilder.InsertData(
                table: "Sector",
                columns: new[] { "SectorKey", "GovernrateKey", "SectorName" },
                values: new object[,]
                {
                    { 1, 1, "North" },
                    { 2, 1, "East" },
                    { 3, 1, "West" },
                    { 4, 1, "South" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 1, 1, "gov 1 (cairo for example)", 1, null });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 2, 1, "Sector", 1 });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "ZoneKey", "SectorKey", "ZoneName" },
                values: new object[,]
                {
                    { 1, 1, "منطقه اولى" },
                    { 2, 1, "منطقه ثانيه" },
                    { 3, 1, "منطقه ثالثه" },
                    { 4, 1, "منطقه رابعه" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityKey", "CityName", "ZoneKey" },
                values: new object[,]
                {
                    { 1, "Nasr City", 1 },
                    { 2, "Al Salam City", 1 },
                    { 3, "Dar Al Salam", 2 },
                    { 4, "Helwan", 2 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 2, 1, "sec 1 (north)", 2, 1 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 3, 1, "Zone", 2 });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 3, 1, "Zone 1 (1st)", 3, 2 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 4, 1, "City", 3 });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "StationKey", "CityKey", "StationName" },
                values: new object[,]
                {
                    { 1, 1, "prod-1-1" },
                    { 2, 1, "prod-1-2" },
                    { 3, 2, "prod-2-1" },
                    { 4, 2, "prod-2-2" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 4, 1, "Cty 1 (Nasr City)", 4, 3 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 5, 1, "Station", 4 });

            migrationBuilder.InsertData(
                table: "Tower",
                columns: new[] { "TowerKey", "StationKey", "TowerName" },
                values: new object[,]
                {
                    { 1, 1, "dc-1-1" },
                    { 2, 1, "dc-1-2" },
                    { 3, 2, "dc-2-1" },
                    { 4, 2, "dc-2-2" }
                });

            migrationBuilder.InsertData(
                table: "Cabin",
                columns: new[] { "CabinKey", "CabinName", "TowerKey" },
                values: new object[,]
                {
                    { 1, "cab-1-1", 1 },
                    { 2, "cab-1-2", 1 },
                    { 3, "cab-2-1", 2 },
                    { 4, "cab-2-2", 2 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 5, 1, "Stion 1 (prod-1-1)", 5, 4 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 6, 1, "Tower", 5 });

            migrationBuilder.InsertData(
                table: "Cable",
                columns: new[] { "CableKey", "CabinKey", "CableName" },
                values: new object[,]
                {
                    { 1, 1, "ch-1-1" },
                    { 2, 1, "ch-1-2" },
                    { 3, 2, "ch-2-1" },
                    { 4, 2, "ch-2-2" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 6, 1, "Toer 1 (dc-1-1)", 6, 5 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 7, 1, "Cabin", 6 });

            migrationBuilder.InsertData(
                table: "Block",
                columns: new[] { "BlockKey", "BlockName", "CableKey" },
                values: new object[,]
                {
                    { 1, "111-111-111", 1 },
                    { 2, "222-222-222", 1 },
                    { 3, "333-333-333", 2 },
                    { 4, "444-444-444", 2 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 7, 1, "Cbn 1 (cab-1-1)", 7, 6 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 8, 1, "Cable", 7 });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "BuildingKey", "BlockKey", "BuildingName" },
                values: new object[,]
                {
                    { 1, 1, "asd-1-1" },
                    { 2, 1, "asd-1-2" },
                    { 3, 2, "asd-2-1" },
                    { 4, 2, "asd-2-1" }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 8, 1, "Cbl 1 (ch-1-1)", 8, 7 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 9, 1, "Block", 8 });

            migrationBuilder.InsertData(
                table: "Flat",
                columns: new[] { "FlatKey", "BuildingKey" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 9, 1, "Blk 1 (111-111-111)", 9, 8 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 10, 1, "Building", 9 });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 10, 1, "Blding 1 (asd-1-1)", 10, 9 });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[,]
                {
                    { 11, 1, "Flat", 10 },
                    { 13, 1, "Corporate Subscription", 10 }
                });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "SubscriptionKey", "BuildingKey", "FlatKey", "MeterKey", "PaletKey" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 11 },
                    { 2, 1, 2, 1, 2 },
                    { 3, 2, 3, 1, 3 },
                    { 4, 2, 4, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[,]
                {
                    { 11, 1, "Flt 1 (1)", 11, 10 },
                    { 13, 2, "Corp Subs 1 (3)", 13, 10 }
                });

            migrationBuilder.InsertData(
                table: "NetworkElementTypes",
                columns: new[] { "NetworkElementTypeKey", "NetworkElementHierarchyPathKey", "NetworkElementTypeName", "ParentNetworkElementTypeKey" },
                values: new object[] { 12, 1, "Invidual Subscription", 11 });

            migrationBuilder.InsertData(
                table: "NetworkElement",
                columns: new[] { "NetworkElementKey", "NetworkElementHierarchyPathKey", "NetworkElementName", "NetworkElementTypeKey", "ParentNetworkElementKey" },
                values: new object[] { 12, 1, "Indv Subs 1 (1)", 12, 11 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Block",
                keyColumn: "BlockKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Block",
                keyColumn: "BlockKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "BuildingKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "BuildingKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cabin",
                keyColumn: "CabinKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cabin",
                keyColumn: "CabinKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cable",
                keyColumn: "CableKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cable",
                keyColumn: "CableKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernrateKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernrateKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernrateKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProblemTypes",
                keyColumn: "ProblemTypeKey",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sector",
                keyColumn: "SectorKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sector",
                keyColumn: "SectorKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sector",
                keyColumn: "SectorKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "StationKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "StationKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "SubscriptionKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "TowerKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "TowerKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Block",
                keyColumn: "BlockKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cabin",
                keyColumn: "CabinKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cable",
                keyColumn: "CableKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flat",
                keyColumn: "FlatKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flat",
                keyColumn: "FlatKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flat",
                keyColumn: "FlatKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flat",
                keyColumn: "FlatKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "NetworkElementHierarchyPath",
                keyColumn: "NetworkElementHierarchyPathKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "StationKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "TowerKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "BuildingKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "BuildingKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Block",
                keyColumn: "BlockKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cable",
                keyColumn: "CableKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cabin",
                keyColumn: "CabinKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "TowerKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "StationKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sector",
                keyColumn: "SectorKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernrateKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElement",
                keyColumn: "NetworkElementKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NetworkElementTypes",
                keyColumn: "NetworkElementTypeKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetworkElementHierarchyPath",
                keyColumn: "NetworkElementHierarchyPathKey",
                keyValue: 1);
        }
    }
}
