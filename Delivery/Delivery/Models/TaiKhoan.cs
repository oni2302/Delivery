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
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;

    public partial class TaiKhoan
    {
        public int MaNhanVien { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "ban chua dang nhap")]
        [DataType(DataType.Password)]
        [Display(Name = "M�t kh�u hien tai")]
        public string oldPassword { get; set; }
        [Required(ErrorMessage = "Ban chua nhap m�t khau moi")]
        [StringLength(100, ErrorMessage = "M�t khau m�i toi da {0} ky tu v� toi thi�u {2} ky ty.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mat khau moi")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "X�c thuc m�t khau moi")]
        [Compare("NewPassword", ErrorMessage = "M�t khau m�i v� x�c thuc m�t khau m�i kh�ng kh�p.")]
        public string ConfirmPassword { get; set; }
    }
}
