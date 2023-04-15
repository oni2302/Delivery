using Delivery.Models;
using System.Web.Mvc;


namespace Delivery.Controllers
{
    public class BaseController : Controller
    {
       protected GiaoHangEntities database = new GiaoHangEntities();
    }
}