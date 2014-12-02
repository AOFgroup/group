namespace HostelPro.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataMaster : DbContext
    {
        public DataMaster()
            : base("name=DataMaster")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<HostelName> HostelNames { get; set; }
        public virtual DbSet<HostelNameToCity> HostelNameToCities { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.CITY1)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Hostels)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.HostelNameToCities)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Information)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Hostel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HostelName>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HostelName>()
                .HasMany(e => e.HostelNameToCities)
                .WithRequired(e => e.HostelName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);
        }
    }
}
