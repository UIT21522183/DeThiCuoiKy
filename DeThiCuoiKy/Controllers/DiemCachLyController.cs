using DeThiCuoiKy.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeThiCuoiKy.Controllers
{
	public class DiemCachLyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult EnterDiemCachLy() 
		{
			return View();
		}

		public IActionResult InsertDCL (DIEMCACHLY dcl)
		{
			int count;
			DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
		
				count = context.sqlInsertDCL(dcl);
				if (count > 0)
				{
					ViewData["thongbao"] = "Insert thành công";
				}
				else
				{
					ViewData["thongbao"] = "Insert không thành công";
				
			}
			return View();
		}

		public IActionResult ListTenDiemCachLy()
		{
            DataContext context = HttpContext.RequestServices.GetService(typeof(DeThiCuoiKy.Models.DataContext)) as DataContext;
            return View(context.getListTenDiemCachLy());
        }

	}
}
