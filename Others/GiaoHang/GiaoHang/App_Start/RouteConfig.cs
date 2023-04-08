using GiaoHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiaoHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Controler NhanVien
            RouteItem.routesList.Add(new RouteItem("DanhSachNhanVien", "danhsach/nhanvien", "NhanVien", "DanhSach"));
            RouteItem.routesList.Add(new RouteItem("ThemNhanVien", "themnhanvien", "NhanVien", "Them"));
            RouteItem.routesList.Add(new RouteItem("ThongTinCaNhan", "thongtincanhan", "NhanVien", "ChiTiet"));
            RouteItem.routesList.Add(new RouteItem("ChiTietNhanVien", "nhanvien/{id}", "NhanVien", "ChiTiet"));

            //Controller TaiKhoan
            RouteItem.routesList.Add(new RouteItem("DangNhap", "DangNhap", "Authentication", "Login"));
            RouteItem.routesList.Add(new RouteItem("XuLiDangNhap", "XuLiDangNhap", "Authentication", "LoginValidate"));

            RouteItem.routesList.Add(new RouteItem("DangXuat", "DangXuat", "Authentication", "Logout"));
            //


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // Tự động thêm route bên trên 
            foreach (var item in RouteItem.routesList)
            {
                routes.MapRoute(
                    name: item.Name,
                    url: item.Url,
                    defaults: new { controller = item.Controler, action = item.Action, id = UrlParameter.Optional }
                );
            }

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NhanVien", action = "DanhSach", id = UrlParameter.Optional }
            );
        }
    }
}
