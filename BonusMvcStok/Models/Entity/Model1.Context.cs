﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BonusMvcStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMvcStokEntities : DbContext
    {
        public DbMvcStokEntities()
            : base("name=DbMvcStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_kategori> Tbl_kategori { get; set; }
        public virtual DbSet<tbl_musteri> tbl_musteri { get; set; }
        public virtual DbSet<tbl_personel> tbl_personel { get; set; }
        public virtual DbSet<tbl_satislar> tbl_satislar { get; set; }
        public virtual DbSet<Tbl_urunler> Tbl_urunler { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
    }
}
