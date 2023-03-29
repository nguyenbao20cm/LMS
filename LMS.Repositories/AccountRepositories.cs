
using LMS.DTO.Request.AccountRequest;
using LMS.Model.Model;
using LMS.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc;
using LMS.DTO.Request.TeachingSubject;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using LMS.DTO.Helper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Data.Sql;
using LMS.DTO.Request.TaiKhoanRequest;

namespace LMS.Repositories
{
    public interface ITaiKhoanRepository
    {
        bool CheckID(int id);
        
       List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        bool ChangePassword(int id, string pass);
        bool create(CreateAccFileANh clr);
        bool update(Account clr);
        bool delete(int id);
        List<Account> GetAll();
        Account GetById(int id);
        LoginSucess Authencate(string username,string password );
        Account Detail(int id);
        public bool ChangeAvatar(int id, IFormFile image);
        public bool CheckPass(int id, string pass);
    }
    public class AccountRepositories : ITaiKhoanRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _environment;
        private readonly AppSettings _appSettings;

        public AccountRepositories(AppDbContext context, IWebHostEnvironment _environment,IConfiguration configuration)
        {
            this.context = context;
            this._environment = _environment;
            this._appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        }
        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
         var a=context.TeachingSubject.
                Include(c => c.ClassRoom)
                .Include(c => c.Subject).
                Include(c => c.Account).Where(c=>c.AccountID==id).ToList();
            List<TeachingSubjectGetAll> result = new();
            TeachingSubjectGetAll temp = new();
            foreach (var item in a)
            {
                temp.SubjectId = item.SubjectID;
                temp.SubjectName = item.Subject.Name;
                temp.Desc = item.Subject.Describe;
                temp.Status = item.Subject.Status;
                temp.Document = item.Subject.Document;
                result.Add(temp);
            }
            return result;
        }
       
        public LoginSucess Authencate(string username,string password)
        {
           
            var check = context.TaiKhoan.Where(x => x.MatKhau == password).Where(x => x.TenDangNhap == username).FirstOrDefault();
            if (check != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);// lay key trong appsetting
                var tokenDescriptor = new SecurityTokenDescriptor
                {   
                    Subject = new ClaimsIdentity(new[] 
                    {
                       new Claim("id", check.TaiKhoanId.ToString()),
                       new Claim("Name", check.TenNguoiDung.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return new LoginSucess(check,jwtToken);
            }
            return null;

        }
        
        public bool ChangePassword(int id, string pass)
        {
            var a = context.TaiKhoan.Where(x => x.TaiKhoanId == id).FirstOrDefault();
            a.MatKhau = pass;
            context.Update(a);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool create(CreateAccFileANh clr)
        {
            
            int check=0;
            if (clr.ImageFile != null)
            {
                var fileName = clr.ImageFile.FileName;
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
        public bool ChangeAvatar(int id,IFormFile image)
        {
            int check =0;
            if (image != null)
            {
                var fileName =image.FileName;
                var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                var uploadPath = Path.Combine(uploadFolder, fileName);
            
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    image.CopyTo(fs);
                    fs.Flush();
                }
               

                var result = context.TaiKhoan.Where(x => x.TaiKhoanId == id).FirstOrDefault();
                result.AnhDaiDien = fileName;
                
                context.TaiKhoan.Update(result);
                check = context.SaveChanges();
            }
            return check > 0 ? true : false;
        }

        public bool CheckPass(int id, string pass)
        {
           var check = context.TaiKhoan.Where(x=>x.TaiKhoanId==id).Where(x=>x.MatKhau==pass).FirstOrDefault();
            if (check == null) return false;
            else return true;
            
        }

        public bool CheckID(int id)
        {
            var check = context.TaiKhoan.Where(x => x.TaiKhoanId == id).First();
            
            if (check == null) return false;
            else return true;
        }
    }
}
