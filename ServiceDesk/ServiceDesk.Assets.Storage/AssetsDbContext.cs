using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceDesk.Assets.Storage
{
    public class AssetsDbContext: DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Computer> Computers { get; set; }

        public DbSet<Cable> Cables { get; set; }

        public AssetsDbContext(DbContextOptions<AssetsDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Asset>("Asset")
                .HasValue<Computer>("Computer")
                .HasValue<Cable>("Cable");

            modelBuilder.Entity<Asset>()
           .Property(a => a.Id)
           .ValueGeneratedOnAdd(); // Ensure identity column is auto-generated

        }
    }
}
//public DbSet<AssetType> AssetTypes { get; set; }
//public DbSet<AssetCategory> AssetCategories { get; set; }
//public DbSet<Location> Locations { get; set; }
//public DbSet<AssetHistory> AssetHistories { get; set; }
//public DbSet<ContactInfo> Contacts { get; set; }
//public DbSet<Manufacturer> Manufacturers { get; set; }

//public DbSet<ServiceContract> ServiceContracts { get; set; }
//public DbSet<Software> Softwares { get; set; }