
using LMS.DTO.Request.AccountRequest;
using LMS.Model.Model;
using LMS.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public interface ITaiKhoanRepository
    {
        bool create(CreateAccFileANh clr);
        bool update(Account clr);
        bool delete(int id);
        List<Account> GetAll();
        Account GetById(int id);
        bool Authencate(string username,string password );
        Account Detail(int id);


    }
    public class AccountRepositories : ITaiKhoanRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _environment;
        public AccountRepositories(AppDbContext context, IWebHostEnvironment _environment)
        {
            this.context = context;
            this._environment = _environment;
        }

        public bool Authencate(string username,string password)
        {
            var check = context.TaiKhoan.Where(x => x.MatKhau == password).Where(x => x.TenDangNhap == username).FirstOrDefault();
            if (check == null) return false;
            else return true;
        }

        public bool create(CreateAccFileANh clr)
        {
            
            int check=0;
            if (clr.ImageFile != null)
            {
                var fileName = clr.TaiKhoanId.ToString() + Path.GetExtension(clr.ImageFile.FileName);
                var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                var uploadPath = Path.Combine(uploadFolder, fileName);
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    clr.ImageFile.CopyTo(fs);
                    fs.Flush();
                }
                clr.AnhDaiDien = fileName;

                Account Tk = new();
                Tk.TenDangNhap = clr.TenDangNhap;
                Tk.MatKhau = clr.MatKhau;
                Tk.AnhDaiDien = clr.AnhDaiDien;
                Tk.TenNguoiDung = clr.TenNguoiDung;
                Tk.GioiTinh = clr.GioiTinh;
                Tk.VaiTro = clr.VaiTro;
                Tk.Email = clr.Email;
                Tk.SDT = clr.SDT;
                Tk.DiaChi = clr.DiaChi;
                context.TaiKhoan.Add(Tk);
                check = context.SaveChanges();
            }
            return check > 0 ? true : false;
        }



        public bool delete(int id)
        {
            context.TaiKhoan.Remove(context.TaiKhoan.Where(i => i.TaiKhoanId == id).FirstOrDefault());
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public Account Detail(int id)
        {
            return context.TaiKhoan.Where(x=>x.TaiKhoanId==id).FirstOrDefault();
        }

        public List<Account> GetAll()
        {
            return context.TaiKhoan.ToList();
        }

        public Account GetById(int id)
        {
            return context.TaiKhoan.Where(x => x.TaiKhoanId == id).FirstOrDefault();
        }



        public bool update(Account clr)
        {
            context.TaiKhoan.Update(clr);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }


    }
}
