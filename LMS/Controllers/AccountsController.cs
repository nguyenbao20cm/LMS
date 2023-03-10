using LMS.DTO.Request.TaiKhoanRequest;
using LMS.Model.Model;
using LMS.Service;
using Microsoft.AspNetCore.Mvc;

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
        public List<Account> GetAll()
        {
            return taiKhoanService.GetAll();
        }
        [HttpPost]
        public ActionResult Create([FromForm] TaiKhoanCreateRequest clr)
        {
            bool check = taiKhoanService.create(clr);

            return check ? Ok() : BadRequest("create fail");
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, TaiKhoanUpdateRequest clr)
        {
            bool check = taiKhoanService.update(id, clr);

            return check ? Ok() : BadRequest("update fail");
        }
        [HttpGet("{id}")]
        public Account GetById(int id)
        {
            return taiKhoanService.GetById(id);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool check = taiKhoanService.delete(id);

            return check ? Ok() : BadRequest("create fail");
        }
        [HttpPost("{username},{password}")]
        public ActionResult SignIn(string username, string password)
        {
            bool check = taiKhoanService.Authencate(username, password);

            return check ? Ok() : BadRequest("fail");

        }
        [HttpPost("{id}")]
        public ActionResult GetDetailById(int id)
        {
            var check = taiKhoanService.Detail(id);
            if (check == null) return BadRequest("Khong co");
            else
                return Ok(check);
        }
    }
}
