using Microsoft.AspNetCore.Mvc;
using PreExam.Models;

namespace PreExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPI
    {
        QlBanChauCanhContext db = new QlBanChauCanhContext();
        [HttpGet("{maPhanLoai}")]
        public List<SanPham> GetAllProducts(string maPhanLoai)
        {
            var sanPham = db.SanPhams.Where(x => x.MaPhanLoai == maPhanLoai).ToList();
            return sanPham;
        }
    }
}
