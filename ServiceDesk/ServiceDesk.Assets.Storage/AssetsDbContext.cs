using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage
{
    public class AssetsDbContext: DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AssetHistory> AssetHistories { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<ServiceContract> ServiceContracts { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public AssetsDbContext(DbContextOptions<AssetsDbContext> options) : base(options)
        {
        }



    }
}
