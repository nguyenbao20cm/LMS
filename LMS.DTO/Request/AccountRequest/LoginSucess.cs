using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.AccountRequest
{
    public class LoginSucess
    {
   
       
      
        public string AnhDaiDien { get; set; }
        public string TenNguoiDung { get; set; }
        public string GioiTinh { get; set; }
        public int VaiTro { get; set; }//1 la leadership 2 la hoc sinh 3 la giao vien
        public string Email { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string Token { get; set; }
        public LoginSucess(Account user, string token)
        {
            AnhDaiDien = user.AnhDaiDien;
            TenNguoiDung = user.TenNguoiDung;
            GioiTinh = user.GioiTinh;
            VaiTro = user.VaiTro;
            Email = user.Email; SDT = user.SDT;
            DiaChi = user.DiaChi;
            Token = token;
        }
    }
    
}
