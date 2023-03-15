using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using LMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        [HttpGet("GetAllTeachingSubjectByNameAZ/{IdAccount}")]

        public List<TeachingSubjectGetAll> GetAllTeachingSubjects(int IdAccount)
        {
            
            return teacherService.GetAllTeachingSubject(IdAccount);
        }
        [HttpGet("GetDetailsSubject/{IdSubject}")]

        public Task<ActionResult<DetailsSubject>> GetDetailsSubject(int IdSubject)
        {

            return teacherService.GetDetailsSubject(IdSubject);
        }
        [HttpGet("FindTeacherSubjectByIdSubject/{IdAccount},{IdTeacherSubject}")]

        public TeachingSubjectGetAll FindTeacherSubjectByIdSubject(int IdAccount, int IdTeacherSubject)
        {
            return teacherService.FindTeacherSubject(IdAccount, IdTeacherSubject);
        }
        [HttpGet("GetAllTeachingSubject/{IdAccount},{NameTeacherSubject}")]

        public TeachingSubjectGetAll FindTeacherSubjectByNameSubject(int IdAccount, string NameTeacherSubject)
        {
            return teacherService.FindTeacherSubject(IdAccount, NameTeacherSubject);
        }
        [HttpPut("UpdateDetailTeacherSubject/{id}")]
        public ActionResult Update(int id, UpdateSubject clr)
        {
            bool check = teacherService.UpdateDetailTeacherSubject(id, clr);

            return check ? Ok("Sucess") : BadRequest("update fail");
        }
    }
}
