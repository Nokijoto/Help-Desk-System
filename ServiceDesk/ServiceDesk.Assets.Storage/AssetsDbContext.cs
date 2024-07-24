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
        public DbSet<Device> Devices { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<PDU> PDUs { get; set; }
        public DbSet<Entities.Monitor> Monitors { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Simcard> Simcards { get; set; }
        public DbSet<Software> Softwares { get; set; }

        public AssetsDbContext(DbContextOptions<AssetsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Asset>("Asset")
                .HasValue<Computer>("Computer")
                .HasValue<Cable>("Cable")
                .HasValue<Device>("Device")
                .HasValue<Rack>("Rack")
                .HasValue<PDU>("PDU")
                .HasValue<Entities.Monitor>("Monitor")
                .HasValue<Phone>("Phone")
                .HasValue<Printer>("Printer")
                .HasValue<Simcard>("Simcard")
                .HasValue<Software>("Software");

            modelBuilder.Entity<Asset>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd(); // Ensure identity column is auto-generated
        }
    }
}
