using DeThiCuoiKy.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeThiCuoiKy.Controllers
{
    public class CongNhanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CongNhan()
        {
            return View();
        }

        public IActionResult ListCNCL(string  diemcachly)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            ViewBag.congnhan = context.getListCNCL(diemcachly);
            return View(ViewBag.congnhan);
        }

        public IActionResult DeleteCN(string Id)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            int count = context.DeleteCN(Id);
            if (count > 0)
            {
                ViewData["thongbao"] = "Xoa thành công";
            }
            else
            {
                ViewData["thongbao"] = "Xoa không thành công";
            }
            return View();
        }

        public IActionResult ViewCN(string Id)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            CONGNHAN cn = context.ViewCN(Id);
            return View(cn);
        }

        public IActionResult UpdateCN(CONGNHAN cn,string MaCongNhanCu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            int count = context.UpdateCN(cn, MaCongNhanCu);
            if (count > 0)
            {
                ViewData["thongbao"] = "Cập nhật thành công";
            }
            else
            {
                ViewData["thongbao"] = "Cập nhật không thành công";
            }
            return View();
        }
    }
}
