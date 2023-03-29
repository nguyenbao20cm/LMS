
using LMS.DTO.Request.AccountRequest;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using LMS.Repositories;
using Microsoft.AspNetCore.Http;

namespace LMS.Service
{
    public interface ITaiKhoanService
    {
       
        bool CheckID(int id);
        List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        bool create(TaiKhoanCreateRequest clr);
        bool update(int id, TaiKhoanUpdateRequest clr);
        bool delete(int id);
        List<Account> GetAll();
        Account GetById(int id);
        Account Detail(int id);
        LoginSucess Authencate(string username, string password);
        public bool ChangeAvatar(int id, IFormFile image);
        bool ChangePassword(int id, string pass);
        public bool CheckPass(int id, string pass);
    }
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly ITaiKhoanRepository TaiKhoanRepository;


        public TaiKhoanService(ITaiKhoanRepository TaiKhoanRepository)
        {
            this.TaiKhoanRepository = TaiKhoanRepository;
        }
        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            
            return TaiKhoanRepository.GetAllTeachingSubject(id);
        }
       
        public bool ChangePassword(int id, string pass)
        {
            if (id == null)
                return false;
            if (pass == null)
                return false;
            return TaiKhoanRepository.ChangePassword(id, pass);
        }
        public LoginSucess Authencate(string username, string password)
        {

          
                return TaiKhoanRepository.Authencate(username, password) ;
        }

        public bool ChangeAvatar(int id, IFormFile image)
        {
            if (id == null) return false;
            if (image == null) return false;
            return TaiKhoanRepository.ChangeAvatar(id, image);
        }

        public bool create(TaiKhoanCreateRequest clr)
        {
            if (clr.TenDangNhap == null)
                if (clr.TenDangNhap == null)
                    return false;
            if (clr.MatKhau == null)
                return false;

            if (clr.TenNguoiDung == null)
                return false;
            if (clr.GioiTinh == null)
                return false;
            if (clr.VaiTro == null)
                return false;
            if (clr.Email == null)
                return false;
            if (clr.SDT == null)
                return false;
            if (clr.DiaChi == null)
                return false;
            CreateAccFileANh Tk = new();
            Tk.TenDangNhap = clr.TenDangNhap;
            Tk.MatKhau = clr.MatKhau;
            Tk.ImageFile = clr.AnhDaiDien;
            Tk.TenNguoiDung = clr.TenNguoiDung;
            Tk.GioiTinh = clr.GioiTinh;
            Tk.VaiTro = clr.VaiTro;
            Tk.Email = clr.Email;
            Tk.SDT = clr.SDT; Tk.DiaChi = clr.DiaChi;
            return TaiKhoanRepository.create(Tk);

        }

        public bool delete(int clr)
        {
            return TaiKhoanRepository.delete(clr);
        }

        public Account Detail(int id)
        {
            var a = TaiKhoanRepository.Detail(id);

            return a;
        }

        public List<Account> GetAll()
        {
            return TaiKhoanRepository.GetAll();
        }

        public Account GetById(int id)
        {
            return TaiKhoanRepository.GetById(id);
        }



        public bool update(int id, TaiKhoanUpdateRequest clr)
        {
            if (clr.TenDangNhap == null)
                return false;
            if (clr.MatKhau == null)
                return false;
            if (clr.AnhDaiDien == null)
                return false;
            if (clr.TenNguoiDung == null)
                return false;
            if (clr.GioiTinh == null)
                return false;
            if (clr.VaiTro == null)
                return false;
            if (clr.Email == null)
                return false;
            if (clr.SDT == null)
                return false;
            if (clr.DiaChi == null)
                return false;
            Account Tk = TaiKhoanRepository.GetById(id);
            Tk.TenDangNhap = clr.TenDangNhap;
            Tk.MatKhau = clr.MatKhau;
            Tk.AnhDaiDien = clr.AnhDaiDien;
            Tk.TenNguoiDung = clr.TenNguoiDung;
            Tk.GioiTinh = clr.GioiTinh;
            Tk.VaiTro = clr.VaiTro;
            Tk.Email = clr.Email;
            Tk.SDT = clr.SDT; Tk.DiaChi = clr.DiaChi;
            return TaiKhoanRepository.update(Tk);
        }

        public bool CheckPass(int id, string pass)
        {
           return TaiKhoanRepository.CheckPass(id, pass);
        }

        public bool CheckID(int id)
        {
            return TaiKhoanRepository.CheckID(id);
        }
    }
}
