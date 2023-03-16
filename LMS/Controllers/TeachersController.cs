using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using LMS.Repositories;
using LMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

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

        public IActionResult GetAllTeachingSubjects(int IdAccount)
        {
            var a = teacherService.GetAllTeachingSubject(IdAccount);
            if (a.Count() > 0)
            {
                return Ok(teacherService.GetAllTeachingSubject(IdAccount));
            }
            //if (teacherService.GetAllTeachingSubject(IdAccount) != null)
            //    return Ok(teacherService.GetAllTeachingSubject(IdAccount));
            else
                return BadRequest("Error");

           
        }
        [HttpGet("GetDetailsSubject/{IdSubject}")]
        public ActionResult GetDetailsSubject(int IdSubject)
        {
            var a = teacherService.GetDetailsSubject(IdSubject);
            if (teacherService.GetDetailsSubject(IdSubject) == null) return BadRequest("Error");



            return Ok(teacherService.GetDetailsSubject(IdSubject));
        }
        [HttpGet("GetInformationDetailsSubject/{IdSubject}")]
        public ActionResult GetAllDetailsSubject(int IdSubject)
        {
            //var a = teacherService.CheckIdSubject(IdSubject);
            //if (teacherService.CheckIdSubject(IdSubject) == true)
            //{
                return Ok(teacherService.detailsSubjects(IdSubject));
            //}
            //else { return BadRequest("Error"); }

        }
        [HttpGet("FindTeacherSubjectByIdSubject/{IdAccount},{IdTeacherSubject}")]

        public IActionResult FindTeacherSubjectByIdSubject(int IdAccount, int IdTeacherSubject)
        {
           
            if (teacherService.FindTeacherSubject(IdAccount, IdTeacherSubject) != null)
                return Ok(teacherService.FindTeacherSubject(IdAccount, IdTeacherSubject));
            else
                return BadRequest("Error");
        }
        [HttpGet("GetAllTeachingSubject/{IdAccount},{NameTeacherSubject}")]

        public IActionResult FindTeacherSubjectByNameSubject(int IdAccount, string NameTeacherSubject)
        {
            if (teacherService.FindTeacherSubject(IdAccount, NameTeacherSubject) != null)
                return Ok(teacherService.FindTeacherSubject(IdAccount, NameTeacherSubject));
            else
                return BadRequest("Error");
        }
        [HttpPut("UpdateDetailTeacherSubject/{id}")]
        public ActionResult Update(int id, UpdateSubject clr)
        {
            bool check = teacherService.UpdateDetailTeacherSubject(id, clr);

            return check ? Ok("Sucess") : BadRequest("update fail");
        }
        [HttpPost]
        [Route("CreateInformationSubject")]
        public ActionResult CreateInformationDetailSubject([FromForm] AddDetailsSubject DetailsSubject)
        {
          
            bool check = teacherService.CreateInformationDetailSubject(DetailsSubject);

            return check ? Ok("Sucess") : BadRequest("Create fail");
        }
        [HttpPut("UpdateInformationTeacherSubject/{id}")]
        public ActionResult UpdateInformationTeacherSubject(int id, UpdateDetailSubject clr)
        {
            bool check = teacherService.UpdateInformationDetailSubject(id, clr);

            return check ? Ok("Sucess") : BadRequest("update fail");
        }
        [HttpDelete("UpdateInformationTeacherSubject/{id}")]
        public ActionResult Delete(int id)
        {
            bool check = teacherService.DeleteInformationDetailSubject(id);

            return check ? Ok() : BadRequest("delete fail");
        }
    }
}
