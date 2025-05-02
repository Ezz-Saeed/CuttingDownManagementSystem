using APIs.Models.FTA;
using APIs.Models.FTA.Hierarchy;
using APIs.Models.FTA.IncidentData;
using APIs.Models.STA.IncidentsAndProblems;
using APIs.Models.STA.Structure;
using Microsoft.EntityFrameworkCore;

namespace APIs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Governrate> Governorates { get; set; }
        public virtual DbSet<ProblemType> ProblemTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<NetworkElementType> NetworkElementTypes { get; set; }
        public virtual DbSet<CuttingDownHeader> CuttingDownHeaders { get; set; }
        public virtual DbSet<CuttingDownIgnored> CuttingDownIgnored { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed STA Structure
            modelBuilder.Entity<Governrate>().HasData(
                new { GovernrateKey = 1, GovernrateName = "Cairo" },
                new { GovernrateKey = 2, GovernrateName = "Alex" },
                new { GovernrateKey = 3, GovernrateName = "Giza" },
                new { GovernrateKey = 4, GovernrateName = "Suez" }
            );

            modelBuilder.Entity<Sector>().HasData(
                new { SectorKey = 1, GovernrateKey = 1, SectorName = "North" },
                new { SectorKey = 2, GovernrateKey = 1, SectorName = "East" },
                new { SectorKey = 3, GovernrateKey = 1, SectorName = "West" },
                new { SectorKey = 4, GovernrateKey = 1, SectorName = "South" }
            );

            modelBuilder.Entity<Zone>().HasData(
                new { ZoneKey = 1, SectorKey = 1, ZoneName = "منطقه اولى" },
                new { ZoneKey = 2, SectorKey = 1, ZoneName = "منطقه ثانيه" },
                new { ZoneKey = 3, SectorKey = 1, ZoneName = "منطقه ثالثه" },
                new { ZoneKey = 4, SectorKey = 1, ZoneName = "منطقه رابعه" }
            );

            modelBuilder.Entity<City>().HasData(
                new { CityKey = 1, ZoneKey = 1, CityName = "Nasr City" },
                new { CityKey = 2, ZoneKey = 1, CityName = "Al Salam City" },
                new { CityKey = 3, ZoneKey = 2, CityName = "Dar Al Salam" },
                new { CityKey = 4, ZoneKey = 2, CityName = "Helwan" }
            );

            modelBuilder.Entity<Station>().HasData(
                new { StationKey = 1, CityKey = 1, StationName = "prod-1-1" },
                new { StationKey = 2, CityKey = 1, StationName = "prod-1-2" },
                new { StationKey = 3, CityKey = 2, StationName = "prod-2-1" },
                new { StationKey = 4, CityKey = 2, StationName = "prod-2-2" }
            );

            modelBuilder.Entity<Tower>().HasData(
                new { TowerKey = 1, StationKey = 1, TowerName = "dc-1-1" },
                new { TowerKey = 2, StationKey = 1, TowerName = "dc-1-2" },
                new { TowerKey = 3, StationKey = 2, TowerName = "dc-2-1" },
                new { TowerKey = 4, StationKey = 2, TowerName = "dc-2-2" }
            );

            modelBuilder.Entity<Cabin>().HasData(
                new { CabinKey = 1, TowerKey = 1, CabinName = "cab-1-1" },
                new { CabinKey = 2, TowerKey = 1, CabinName = "cab-1-2" },
                new { CabinKey = 3, TowerKey = 2, CabinName = "cab-2-1" },
                new { CabinKey = 4, TowerKey = 2, CabinName = "cab-2-2" }
            );

            modelBuilder.Entity<Cable>().HasData(
                new { CableKey = 1, CabinKey = 1, CableName = "ch-1-1" },
                new { CableKey = 2, CabinKey = 1, CableName = "ch-1-2" },
                new { CableKey = 3, CabinKey = 2, CableName = "ch-2-1" },
                new { CableKey = 4, CabinKey = 2, CableName = "ch-2-2" }
            );

            modelBuilder.Entity<Block>().HasData(
                new { BlockKey = 1, CableKey = 1, BlockName = "111-111-111" },
                new { BlockKey = 2, CableKey = 1, BlockName = "222-222-222" },
                new { BlockKey = 3, CableKey = 2, BlockName = "333-333-333" },
                new { BlockKey = 4, CableKey = 2, BlockName = "444-444-444" }
            );

            modelBuilder.Entity<Building>().HasData(
                new { BuildingKey = 1, BlockKey = 1, BuildingName = "asd-1-1" },
                new { BuildingKey = 2, BlockKey = 1, BuildingName = "asd-1-2" },
                new { BuildingKey = 3, BlockKey = 2, BuildingName = "asd-2-1" },
                new { BuildingKey = 4, BlockKey = 2, BuildingName = "asd-2-1" }
            );

            modelBuilder.Entity<Flat>().HasData(
                new { FlatKey = 1, BuildingKey = 1 },
                new { FlatKey = 2, BuildingKey = 1 },
                new { FlatKey = 3, BuildingKey = 2 },
                new { FlatKey = 4, BuildingKey = 2 }
            );

            modelBuilder.Entity<Subscription>().HasData(
                new { SubscriptionKey = 1, FlatKey = 1, BuildingKey = 1, MeterKey = 1, PaletKey = 11 },
                new { SubscriptionKey = 2, FlatKey = 2, BuildingKey = 1, MeterKey = 1, PaletKey = 2 },
                new { SubscriptionKey = 3, FlatKey = 3, BuildingKey = 2, MeterKey = 1, PaletKey = 3 },
                new { SubscriptionKey = 4, FlatKey = 4, BuildingKey = 2, MeterKey = 1, PaletKey = 4 }
            );

            // Seed STA IncidentsAndProblems
            modelBuilder.Entity<ProblemType>().HasData(
            new { ProblemTypeKey = 1, ProblemTypeName = "حريق" },
            new { ProblemTypeKey = 2, ProblemTypeName = "ضغط عالى" },
            new { ProblemTypeKey = 3, ProblemTypeName = "استهلاك عالى" },
            new { ProblemTypeKey = 4, ProblemTypeName = "مديونيه" },
            new { ProblemTypeKey = 5, ProblemTypeName = "تلف عداد" },
            new { ProblemTypeKey = 6, ProblemTypeName = "سرقة تيار" },
            new { ProblemTypeKey = 7, ProblemTypeName = "امطار" },
            new { ProblemTypeKey = 8, ProblemTypeName = "كسر ماسورة مياه" },
            new { ProblemTypeKey = 9, ProblemTypeName = "كسر ماسورة غاز" },
            new { ProblemTypeKey = 10, ProblemTypeName = "تحديث واحلال" },
            new { ProblemTypeKey = 11, ProblemTypeName = "صيانه" },
            new { ProblemTypeKey = 12, ProblemTypeName = "كابل مقطوع" },
            new { ProblemTypeKey = 13, ProblemTypeName = "توصيل كابل" }
            );


            // Seed FTA Hierarchy
            modelBuilder.Entity<Channel>().HasData(
            new { ChannelKey = 1, ChannelName = "Source A" },
            new { ChannelKey = 2, ChannelName = "Source B" }
            );

            modelBuilder.Entity<User>().HasData(
            new { UserKey = 1, Name = "admin", Password = "admin" },
            new { UserKey = 2, Name = "test", Password = "test" },
            new { UserKey = 3, Name = "SourceA", Password = "SourceA" },
            new { UserKey = 4, Name = "SourceB", Password = "SourceB" }
            );

            modelBuilder.Entity<NetworkElementHierarchyPath>().HasData(
            new
            {
                NetworkElementHierarchyPathKey = 1,
                NetworkElementHierarchyPathName = "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Flat, Individual Subscription",
                Abbreviation = "Governrate -> Individual Subscription"
            },
            new
            {
                NetworkElementHierarchyPathKey = 2,
                NetworkElementHierarchyPathName = "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Corporate Subscription",
                Abbreviation = "Governrate -> Corporate Subscription"
            }
            );

            modelBuilder.Entity<NetworkElementType>().HasData(
            new { NetworkElementTypeKey = 1, NetworkElementTypeName = "Governrate", ParentNetworkElementTypeKey = (int?)null, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 2, NetworkElementTypeName = "Sector", ParentNetworkElementTypeKey = 1, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 3, NetworkElementTypeName = "Zone", ParentNetworkElementTypeKey = 2, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 4, NetworkElementTypeName = "City", ParentNetworkElementTypeKey = 3, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 5, NetworkElementTypeName = "Station", ParentNetworkElementTypeKey = 4, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 6, NetworkElementTypeName = "Tower", ParentNetworkElementTypeKey = 5, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 7, NetworkElementTypeName = "Cabin", ParentNetworkElementTypeKey = 6, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 8, NetworkElementTypeName = "Cable", ParentNetworkElementTypeKey = 7, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 9, NetworkElementTypeName = "Block", ParentNetworkElementTypeKey = 8, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 10, NetworkElementTypeName = "Building", ParentNetworkElementTypeKey = 9, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 11, NetworkElementTypeName = "Flat", ParentNetworkElementTypeKey = 10, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 12, NetworkElementTypeName = "Invidual Subscription", ParentNetworkElementTypeKey = 11, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementTypeKey = 13, NetworkElementTypeName = "Corporate Subscription", ParentNetworkElementTypeKey = 10, NetworkElementHierarchyPathKey = 1 }
            );


            modelBuilder.Entity<NetworkElement>().HasData(
            new { NetworkElementKey = 1, NetworkElementName = "gov 1 (cairo for example)", NetworkElementTypeKey = 1, ParentNetworkElementKey = (int?)null, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 2, NetworkElementName = "sec 1 (north)", NetworkElementTypeKey = 2, ParentNetworkElementKey = 1, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 3, NetworkElementName = "Zone 1 (1st)", NetworkElementTypeKey = 3, ParentNetworkElementKey = 2, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 4, NetworkElementName = "Cty 1 (Nasr City)", NetworkElementTypeKey = 4, ParentNetworkElementKey = 3, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 5, NetworkElementName = "Stion 1 (prod-1-1)", NetworkElementTypeKey = 5, ParentNetworkElementKey = 4, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 6, NetworkElementName = "Toer 1 (dc-1-1)", NetworkElementTypeKey = 6, ParentNetworkElementKey = 5, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 7, NetworkElementName = "Cbn 1 (cab-1-1)", NetworkElementTypeKey = 7, ParentNetworkElementKey = 6, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 8, NetworkElementName = "Cbl 1 (ch-1-1)", NetworkElementTypeKey = 8, ParentNetworkElementKey = 7, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 9, NetworkElementName = "Blk 1 (111-111-111)", NetworkElementTypeKey = 9, ParentNetworkElementKey = 8, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 10, NetworkElementName = "Blding 1 (asd-1-1)", NetworkElementTypeKey = 10, ParentNetworkElementKey = 9, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 11, NetworkElementName = "Flt 1 (1)", NetworkElementTypeKey = 11, ParentNetworkElementKey = 10, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 12, NetworkElementName = "Indv Subs 1 (1)", NetworkElementTypeKey = 12, ParentNetworkElementKey = 11, NetworkElementHierarchyPathKey = 1 },
            new { NetworkElementKey = 13, NetworkElementName = "Corp Subs 1 (3)", NetworkElementTypeKey = 13, ParentNetworkElementKey = 10, NetworkElementHierarchyPathKey = 2 }
            );



            // Seed FTA Hierarchy IncidentData

        }

        //public virtual DbSet<Block> Blocks { get; set; }
        //public virtual DbSet<Building> Buildings { get; set; }
        //public virtual DbSet<Cabin> Cabins { get; set; }
        //public virtual DbSet<Cabin> Cable { get; set; }
        //public virtual DbSet<City> Cities { get; set; }
        //public virtual DbSet<Flat> Flats { get; set; }
        //public virtual DbSet<Governorate> Governorates { get; set; }
        //public virtual DbSet<Sector> Sectors { get; set; }
        //public virtual DbSet<Station> Stations { get; set; }
        //public virtual DbSet<Subscription> Subscriptions { get; set; }
        //public virtual DbSet<Tower> Towers { get; set; }
        //public virtual DbSet<Zone> Zones { get; set; }
    }
}
