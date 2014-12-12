namespace HostelPro.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HostelPro.ModelView;

    public partial class MasterData : DbContext
    {
        public MasterData()
            : base("name=MasterData")
        {
        }

        public virtual DbSet<BED> BEDs { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingBed> BookingBeds { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<HostelRole> HostelRoles { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BED>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Booking>()
                .Property(e => e.TotalSum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Booking>()
                .HasMany(e => e.BookingBeds)
                .WithRequired(e => e.Booking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CITY1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Hash)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Salt)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Hostel>()
                .Property(e => e.Information)
                .IsUnicode(false);

            modelBuilder.Entity<HostelRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

          
        }
    }
}
