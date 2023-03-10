using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.AccountRequest
{
    public class CreateAccFileANh
    {
        public int TaiKhoanId { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        
        public IFormFile ImageFile { get; set; }
        public string AnhDaiDien { get; set; }
        public string TenNguoiDung { get; set; }
        public string GioiTinh { get; set; }
        public int VaiTro { get; set; }//1 la leadership 2 la hoc sinh 3 la giao vien
        public string Email { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
    }
}
