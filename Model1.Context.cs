﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Renat_A_Ride.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentARideEntitiesDatabase : DbContext
    {
        public RentARideEntitiesDatabase()
            : base("name=RentARideEntitiesDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<airportService> airportServices { get; set; }
        public virtual DbSet<carOwner> carOwners { get; set; }
        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<dailyService> dailyServices { get; set; }
        public virtual DbSet<driver> drivers { get; set; }
        public virtual DbSet<hourlyService> hourlyServices { get; set; }
        public virtual DbSet<monthlyService> monthlyServices { get; set; }
        public virtual DbSet<normalService> normalServices { get; set; }
        public virtual DbSet<premiumService> premiumServices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<weeklyService> weeklyServices { get; set; }
    }
}
