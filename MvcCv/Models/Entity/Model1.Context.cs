﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcCv.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbCVEntities1 : DbContext
    {
        public dbCVEntities1()
            : base("name=dbCVEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<tbl_Deneyimlerim> tbl_Deneyimlerim { get; set; }
        public virtual DbSet<tbl_Egitimler> tbl_Egitimler { get; set; }
        public virtual DbSet<tbl_Hakkimda> tbl_Hakkimda { get; set; }
        public virtual DbSet<tbl_Hobilerim> tbl_Hobilerim { get; set; }
        public virtual DbSet<tbl_Iletisim> tbl_Iletisim { get; set; }
        public virtual DbSet<tbl_Yeteneklerim> tbl_Yeteneklerim { get; set; }
        public virtual DbSet<Sertifikalar> Sertifikalar { get; set; }
        public virtual DbSet<tbl_SosyalMedya> tbl_SosyalMedya { get; set; }
    }
}
