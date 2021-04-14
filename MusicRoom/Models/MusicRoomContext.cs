using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class MusicRoomContext : DbContext
    {
        //Fluent API for many-to-many relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Genres-Bands
            modelBuilder.Entity<Genre>()
              .HasMany(t => t.Bands)
              .WithMany(t => t.Genres)
              .Map(m =>
              {
                m.ToTable("GenreBands");
                m.MapLeftKey("Genre_Id");
                m.MapRightKey("Band_Id");
              });

            //Instruments-Bands
            modelBuilder.Entity<Instrument>()
              .HasMany(t => t.Bands)
              .WithMany(t => t.Instruments)
              .Map(m =>
              {
                  m.ToTable("InstrumentBands");
                  m.MapLeftKey("Instrument_Id");
                  m.MapRightKey("Band_Id");
              });

            //Instruments-Users
            modelBuilder.Entity<Instrument>()
              .HasMany(t => t.Users)
              .WithMany(t => t.Instruments)
              .Map(m =>
              {
                  m.ToTable("InstrumentUsers");
                  m.MapLeftKey("Instrument_Id");
                  m.MapRightKey("User_Id");
              });

            //Users-Bands
            modelBuilder.Entity<User>()
              .HasMany(t => t.Bands)
              .WithMany(t => t.Users)
              .Map(m =>
              {
                  m.ToTable("UserBands");
                  m.MapLeftKey("User_Id");
                  m.MapRightKey("Band_Id");
              });

            //Users-Genres
            modelBuilder.Entity<User>()
              .HasMany(t => t.Genres)
              .WithMany(t => t.Users)
              .Map(m =>
              {
                  m.ToTable("UserGenres");
                  m.MapLeftKey("User_Id");
                  m.MapRightKey("Genre_Id");
              });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GearRequest> GearRequests { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}