using HotelReservationNew.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Context
{
    public class HotelReservationNewDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 

        }
        public HotelReservationNewDBContext()
        {
            Database.Connection.ConnectionString = "Data Source=.;Database=HotelReservationNew;trusted_connection=true;MultipleActiveResultSets=True";
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomPicture> RoomPicture { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CreditCards> CreditCards { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Admin> Admin{ get; set; }
    }
}