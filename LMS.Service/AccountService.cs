
using LMS.DTO.Request.AccountRequest;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.Model.Model;
using LMS.Repositories;



namespace LMS.Service
{
    public interface ITaiKhoanService
    {
        bool create(TaiKhoanCreateRequest clr);
        bool update(int id, TaiKhoanUpdateRequest clr);
        bool delete(int id);
        List<Account> GetAll();
        Account GetById(int id);
        Account Detail(int id);
        bool Authencate(string username, string password);


    }
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly ITaiKhoanRepository TaiKhoanRepository;


        public TaiKhoanService(ITaiKhoanRepository TaiKhoanRepository)
        {
            this.TaiKhoanRepository = TaiKhoanRepository;
        }


        public bool Authencate(string username, string password)
        {

            if (username == null)
                return false;
            if (password == null)
                return false;
            if (TaiKhoanRepository.Authencate(username, password) == true) return true;
            else
                return false;
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
            Tk.ImageFile = clr.ImageFile;
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
            var a= TaiKhoanRepository.Detail(id);

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
    }
}
