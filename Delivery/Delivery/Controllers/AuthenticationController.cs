using System;
using Delivery.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class AuthenticationController : Controller
    {
        GiaoHangEntities database = new GiaoHangEntities();
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
                string truePass = database.TaiKhoan_LayMatKhau(username).FirstOrDefault();
                //truePass = PasswordOption.Decrypt(truePass); 
                if(truePass == null)
                {
                    ModelState.AddModelError("", "Tài khoản không đúng hoặc bị khóa !");
                    return Login();
                }    
                //
                if (truePass == password)
                {
                    //Lấy thông tin nhân viên 
                    var userInfo = database.TaiKhoan_DangNhap(username).SingleOrDefault();
                    Session.Add(CommonConstants.NGUOI_DUNG,userInfo);
                    //Lấy menu của nhân viên
                    Session.Add(CommonConstants.MENU, database.MenuOf(userInfo.MaNhanVien).ToList());

                    //Trang thông tin cá nhân
                    //return RedirectToRoute("ThongTinCaNhan");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng !");
                    //return RedirectToRoute("DangNhap");
                    return Login();
                }
            }
            else
            {
                ModelState.AddModelError("", "Chưa nhập tài khoản hoặc mật khẩu !");
                return RedirectToAction("Login");
            }
        }


        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}