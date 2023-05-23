using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreExam.Models;

public partial class SanPham
{
    public string MaSanPham { get; set; } = null!;


    [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
    [RegularExpression(@"^[a-zA-Z].*", ErrorMessage = "Tên sản phẩm bắt đầu bằng chữ cái.")]
    public string TenSanPham { get; set; } = null!;

    public string? MaPhanLoai { get; set; }

    [Required(ErrorMessage = "Bạn phải nhập giá nhập")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Giá nhập phải là chữ số")]
    public long? GiaNhap { get; set; }

    [Required(ErrorMessage = "Bạn phải nhập đơn giá bán nhỏ nhất")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Giá bán nhỏ nhất là chữ số")]
    public long? DonGiaBanNhoNhat { get; set; }


    [Required(ErrorMessage = "Bạn phải nhập giá bán lớn nhất")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Giá bán lớn nhất phải là chữ số")]
    public long? DonGiaBanLonNhat { get; set; }

    public bool? TrangThai { get; set; }

    [Required(ErrorMessage = "Bạn phải nhập mô tả ngắn")]
    [RegularExpression(@"^[a-zA-Z].*", ErrorMessage = "Mô tả ngắn bắt đầu bằng chữ cái.")]
    public string? MoTaNgan { get; set; }

    public string? AnhDaiDien { get; set; }

    public bool? NoiBat { get; set; }

    public string? MaPhanLoaiPhu { get; set; }

    public virtual PhanLoai? MaPhanLoaiNavigation { get; set; }

    public virtual PhanLoaiPhu? MaPhanLoaiPhuNavigation { get; set; }

    public virtual ICollection<SptheoMau> SptheoMaus { get; set; } = new List<SptheoMau>();
}
