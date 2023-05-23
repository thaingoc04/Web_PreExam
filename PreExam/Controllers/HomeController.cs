using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PreExam.Models;
using System.Diagnostics;

namespace PreExam.Controllers
{
    public class HomeController : Controller
    {
        QlBanChauCanhContext db = new QlBanChauCanhContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstSanPham = db.SanPhams.ToList();
            return View(lstSanPham);
        }
        public IActionResult ChiTietSanPham(string maSP)
        {
            var lstSanPham = db.SanPhams.SingleOrDefault(x => x.MaSanPham == maSP);
            return View(lstSanPham);
        }
        [Route("ThemSuaSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais.ToList(), "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus.ToList(), "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View();
        }

        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XacNhanThemSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("ChinhSuaSanPham")]
        [HttpGet]
        public IActionResult ChinhSuaSanPham(string MaSanPham)
        {
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais.ToList(), "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus.ToList(), "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            var sp = db.SanPhams.Find(MaSanPham);
            return View(sp);

        }

        [Route("ChinhSuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XacNhanChinhSua(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "Home", new { maSP = sanPham.MaSanPham });
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}