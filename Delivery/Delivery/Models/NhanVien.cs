
//------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

    public partial class NhanVien
{

    public int MaNhanVien { get; set; }

    public string TenNhanVien { get; set; }

    public Nullable<int> MaChucVu { get; set; }

    //[ DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public Nullable<System.DateTime> NgaySinh { get; set; }

    public string Email { get; set; }

    public string SoDienThoai { get; set; }

    public string AnhDaiDien { get; set; }



    public virtual TaiKhoan TaiKhoan { get; set; }

    public virtual ChucVu ChucVu { get; set; }

}

}
