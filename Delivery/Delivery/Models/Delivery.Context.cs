﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DeliveryEntities : DbContext
    {
        public DeliveryEntities()
            : base("name=DeliveryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DH> DHs { get; set; }
        public virtual DbSet<DH_DaNhan> DH_DaNhan { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanChucNang> PhanChucNangs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    
        public virtual ObjectResult<LayChucNang_Result> LayChucNang(Nullable<int> maNhanVien)
        {
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayChucNang_Result>("LayChucNang", maNhanVienParameter);
        }
    }
}
