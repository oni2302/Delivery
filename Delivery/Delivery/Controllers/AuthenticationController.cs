using System;
using Delivery.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoHang.Controllers
{
    public class AuthenticationController : BaseController
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {

            //LOGIN: PROCESSING...
            if (username != null && password != null)
            {   
                //Xử lí mã hóa ở đây
                string truePass = database.TaiKhoan_LayMatKhau(username).Single();
                    //truePass = PasswordOption.Decrypt(truePass); 
                    
                //
                if (truePass == password)
                {
                    //Lấy thông tin nhân viên 
                    var userInfo = database.TaiKhoan_DangNhap(username).Single();
                    Session.Add(CommonConstants.TEN_NGUOI_DUNG,userInfo);
                    //Lấy menu của nhân viên
                    Session.Add(CommonConstants.CHUC_NANG, database.MenuOf(userInfo.MaNhanVien).ToList());

                    //Trang thông tin cá nhân
                    //return RedirectToRoute("ThongTinCaNhan");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng !");
                    //return RedirectToRoute("DangNhap");
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chưa nhập tài khoản hoặc mật khẩu !");
                return RedirectToRoute("DangNhap");
            }
        }









        public ActionResult Logout() {
            Session.Remove(CommonConstants.TEN_NGUOI_DUNG);
            return RedirectToRoute("Login");
        }
    }
}