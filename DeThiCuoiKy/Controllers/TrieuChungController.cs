using DeThiCuoiKy.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeThiCuoiKy.Controllers
{
    public class TrieuChungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrieuChung()
        {
            return View();
        }

        public IActionResult ListTT(int soluong)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            return View(context.getListCongNhan(soluong));
        }


    }
}
