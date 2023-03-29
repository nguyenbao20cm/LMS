using LMS.DTO.Request.AccountRequest;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using LMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITaiKhoanService taiKhoanService;
        public AccountsController(ITaiKhoanService taiKhoanService)
        {
            this.taiKhoanService = taiKhoanService;
        }
        [HttpGet]
        [Route("GetAllAccount")]
        public List<GetAllAccTeacher> GetAll()
        {
            List<GetAllAccTeacher> result =new();
            GetAllAccTeacher Tk = new();
            foreach (var clr in taiKhoanService.GetAll())
            {
                Tk.TaiKhoanId = clr.TaiKhoanId;
                Tk.TenDangNhap = clr.TenDangNhap;
                Tk.MatKhau = clr.MatKhau;
                Tk.AnhDaiDien = clr.AnhDaiDien;
                Tk.TenNguoiDung = clr.TenNguoiDung;
                Tk.GioiTinh = clr.GioiTinh;
                Tk.VaiTro = clr.VaiTro;
                Tk.Email = clr.Email;
                Tk.SDT = clr.SDT; Tk.DiaChi = clr.DiaChi;
                result.Add(Tk);
            }
            return result;

        }
        [HttpPost]
        [Route("SiginUp")]
        public ActionResult Create([FromForm] TaiKhoanCreateRequest clr)
        {
            var regexItem = new Regex("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8}");
            if (regexItem.IsMatch(clr.MatKhau))
            {
                bool check = taiKhoanService.create(clr);

                return check ? Ok() : BadRequest("create fail");
            }
            else return BadRequest("Password Fail");
            return BadRequest("Create Fail");
        }
      
        [HttpPut("UpdateAccount/{id}")]
        public ActionResult Update(int id, TaiKhoanUpdateRequest clr)
        {
            bool check = taiKhoanService.update(id, clr);

            return check ? Ok() : BadRequest("update fail");
        }
        //[HttpGet("{id}")]
        //public Account GetById(int id)
        //{
        //    return taiKhoanService.GetById(id);
        //}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool check = taiKhoanService.delete(id);

            return check ? Ok() : BadRequest("create fail");
        }
        [HttpPost("SiginIn/{username},{password}")]
        //[Route("SiginIn")]
        public ActionResult SignIn(string username, string password)
        {
            var check = taiKhoanService.Authencate(username, password);

            if (check == null) return BadRequest();
            else
                return Ok(check);

        }
        
        [HttpPost("DetailsAccount/{id}")]
        
        public ActionResult GetDetailById(int id)
        {
            var check = taiKhoanService.Detail(id);
            if (check == null) return BadRequest("Khong co");
            else
                return Ok(check);
        }
        [HttpPut]
        [Route("ChangeAvatar")]
        public ActionResult Create(int id, IFormFile image )
        {
            bool check = taiKhoanService.ChangeAvatar(id, image);

            return check ? Ok() : BadRequest("create fail");
        }
        
        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword(int Id, string Passnew,string Passold,string Confirmpass)
        {
            var regexItem = new Regex("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8}");
            var check = taiKhoanService.CheckPass(Id, Passold);
            if (check == true)
            {
                if (regexItem.IsMatch(Passnew))
                {
                    if (Passnew == Confirmpass)
                    {
                        bool check1 = taiKhoanService.ChangePassword(Id, Confirmpass);
                        return check1 ? Ok() : BadRequest("create fail");
                    }
                    else
                        return BadRequest("Pass phai giong nhau");
                }
            }else
                return BadRequest("Pass cu sai ");

            return BadRequest("Change fail");
        }
      
        
       
       
            
    }
}
