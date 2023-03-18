using LMS.DTO.Request.Lesson;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TaiKhoanRequest;
using LMS.DTO.Request.TeachingSubject;
using LMS.DTO.Request.TopicSubject;
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
        [HttpPost]
        [Route("CreateTopicSubject")]
        public ActionResult CreateTopicSubject([FromForm] CreateTopicSubject CreateTopicSubject)
        {

            bool check = teacherService.CreateTopicSubject(CreateTopicSubject);

            return check ? Ok("Sucess") : BadRequest("Create fail");
        }
        [HttpGet]
        [Route("GetAllSubjet")]
        public ActionResult GetAllSubjet()
        {

            return Ok(teacherService.GetAllSubject());
        }
        [HttpGet("GetAllTopicSubject/{IdSubject}")]
        public ActionResult GetAllTopicSubject(int IdSubject)
        { 
            return Ok(teacherService.GetAllTopicSubject(IdSubject));
        }
        [HttpPost]
        [Route("CreateLesson")]
        public ActionResult CreateLesson([FromForm] CreateLesson CreateLesson)
        {

            bool check = teacherService.CreateLesson(CreateLesson);

            return check ? Ok("Sucess") : BadRequest("Create fail");
        }
        [HttpPut("UpdateLesson/{id}")]
        public ActionResult UpdateLesson( int id, [FromForm] UpdateLesson clr)
        {
            bool check = teacherService.UpdateLesson(id, clr);
            return check ? Ok("Sucess") : BadRequest("update fail");
        }
        [HttpPut("UpdateTopicSubject/{IdTopicSubject}")]
        public ActionResult UpdateTopicSubject(int IdTopicSubject, UpdateTopicSubject clr)
        {
            bool check = teacherService.UpdateTopicSubject(IdTopicSubject, clr);
            return check ? Ok("Sucess") : BadRequest("update fail");
        }
        [HttpGet]
        [Route("GetAllClassRooms")]
        public ActionResult GetAllClassRooms()
        {
            return Ok(teacherService.GetAllClassRoom());
           
        }
        [HttpGet("GetLessonFromTopicSubject/{IdTopic}")]

        public IActionResult GetLessonFromTopicSubject(int IdTopic)
        {
            if (teacherService.GetLesson(IdTopic) == null) return BadRequest();
            return Ok(teacherService.GetLesson(IdTopic));
        }
        [HttpGet("GetAllDetailLesson/{IdLesson}")]

        public IActionResult GetAllDetailLesson(int IdLesson)
        {
            if (teacherService.GetAllDetailLesson(IdLesson) == null) return BadRequest();
            return Ok(teacherService.GetAllDetailLesson(IdLesson));
        }

        [HttpPost("CreateDetailLesson/{Idlesson},{IdAcc}")]

        public ActionResult CreateDetailLesson(int Idlesson, int IdAcc, string Name, IFormFile DetailsLesson)
        {

            bool check = teacherService.CreateDetailLesson(Idlesson,IdAcc, Name, DetailsLesson);

            return check ? Ok("Sucess") : BadRequest("Create fail");
        }
        [HttpPut("UpdateDetailLesson/{id}")]
        public ActionResult UpdateDetailLesson(int id,string name, [FromForm] IFormFile clr)
        {
            bool check = teacherService.UpdateDetailLesson(id,name, clr);
            return check ? Ok("Sucess") : BadRequest("update fail");
        }
    }
}
