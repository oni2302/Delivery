﻿using Delivery.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class AccountController : Controller
    {
        GiaoHangEntities db = new GiaoHangEntities();

        //Đăng nhập
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account_DangNhap_Result taiKhoan)
        {
            string username = taiKhoan.TenTaiKhoan;
            string password = taiKhoan.MatKhau;
            //LOGIN: PROCESSING...
            var check = db.Account_DangNhap(username, password).SingleOrDefault();
            if (ModelState.IsValid && username != null && password != null)
            {
                if (check != null)
                {
                    var layChucNang = db.MenuOf(check.MaNhanVien);
                    List<MenuOf_Result> layChucNang_List = new List<MenuOf_Result>();
                    foreach (MenuOf_Result item in layChucNang)
                    {
                        layChucNang_List.Add(item);
                    }
                    Session.Add(CommonConstants.TEN_NGUOI_DUNG, db.TaiKhoan_LayTen(check.MaNhanVien).SingleOrDefault());
                    Session.Add(CommonConstants.NGUOI_DUNG, check);
                    Session.Add(CommonConstants.CHUC_NANG, layChucNang_List);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng !");
                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chưa nhập tài khoản hoặc mật khẩu !");
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}