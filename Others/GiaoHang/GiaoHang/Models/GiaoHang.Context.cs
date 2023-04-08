﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiaoHang.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GiaoHangEntities : DbContext
    {
        public GiaoHangEntities()
            : base("name=GiaoHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Nullable<decimal>> NhanVien_Them(string tenNhanVien, Nullable<System.DateTime> ngaySinh, string email, string soDienThoai, byte[] anhDaiDien, Nullable<int> chucVu)
        {
            var tenNhanVienParameter = tenNhanVien != null ?
                new ObjectParameter("TenNhanVien", tenNhanVien) :
                new ObjectParameter("TenNhanVien", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var soDienThoaiParameter = soDienThoai != null ?
                new ObjectParameter("SoDienThoai", soDienThoai) :
                new ObjectParameter("SoDienThoai", typeof(string));
    
            var anhDaiDienParameter = anhDaiDien != null ?
                new ObjectParameter("AnhDaiDien", anhDaiDien) :
                new ObjectParameter("AnhDaiDien", typeof(byte[]));
    
            var chucVuParameter = chucVu.HasValue ?
                new ObjectParameter("ChucVu", chucVu) :
                new ObjectParameter("ChucVu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("NhanVien_Them", tenNhanVienParameter, ngaySinhParameter, emailParameter, soDienThoaiParameter, anhDaiDienParameter, chucVuParameter);
        }
    
        public virtual ObjectResult<NhanVien_ChiTiet_Result> NhanVien_ChiTiet(Nullable<int> maNhanVien)
        {
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhanVien_ChiTiet_Result>("NhanVien_ChiTiet", maNhanVienParameter);
        }
    
        public virtual ObjectResult<NhanVien_DanhSach_Result> NhanVien_DanhSach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhanVien_DanhSach_Result>("NhanVien_DanhSach");
        }
    
        public virtual ObjectResult<Nullable<int>> NhanVien_Sua(Nullable<int> maNhanVien, string tenNhanVien, Nullable<System.DateTime> ngaySinh, string email, string soDienThoai, byte[] anhDaiDien, Nullable<int> chucVu)
        {
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            var tenNhanVienParameter = tenNhanVien != null ?
                new ObjectParameter("TenNhanVien", tenNhanVien) :
                new ObjectParameter("TenNhanVien", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var soDienThoaiParameter = soDienThoai != null ?
                new ObjectParameter("SoDienThoai", soDienThoai) :
                new ObjectParameter("SoDienThoai", typeof(string));
    
            var anhDaiDienParameter = anhDaiDien != null ?
                new ObjectParameter("AnhDaiDien", anhDaiDien) :
                new ObjectParameter("AnhDaiDien", typeof(byte[]));
    
            var chucVuParameter = chucVu.HasValue ?
                new ObjectParameter("ChucVu", chucVu) :
                new ObjectParameter("ChucVu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("NhanVien_Sua", maNhanVienParameter, tenNhanVienParameter, ngaySinhParameter, emailParameter, soDienThoaiParameter, anhDaiDienParameter, chucVuParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> NhanVien_Xoa(Nullable<int> maNhanVien)
        {
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("NhanVien_Xoa", maNhanVienParameter);
        }
    
        public virtual ObjectResult<MenuOf_Result> MenuOf(Nullable<int> maNhanVien)
        {
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MenuOf_Result>("MenuOf", maNhanVienParameter);
        }
    
        public virtual ObjectResult<TaiKhoan_DangNhap_Result> TaiKhoan_DangNhap(string tenTaiKhoan)
        {
            var tenTaiKhoanParameter = tenTaiKhoan != null ?
                new ObjectParameter("TenTaiKhoan", tenTaiKhoan) :
                new ObjectParameter("TenTaiKhoan", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TaiKhoan_DangNhap_Result>("TaiKhoan_DangNhap", tenTaiKhoanParameter);
        }
    
        public virtual ObjectResult<string> TaiKhoan_LayMatKhau(string tenTaiKhoan)
        {
            var tenTaiKhoanParameter = tenTaiKhoan != null ?
                new ObjectParameter("TenTaiKhoan", tenTaiKhoan) :
                new ObjectParameter("TenTaiKhoan", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("TaiKhoan_LayMatKhau", tenTaiKhoanParameter);
        }
    }
}
