using LMS.DTO.Request.AccountRequest;
using LMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {   
        private readonly ISubjectService subjectservice;
        private readonly IStudentSubjectService studentSubjectService;
        private readonly ITopicSubjectService topicSubjectService;
        private readonly ILessonService lessonService;
        private readonly IDetailsLessonService detailsLessonService;
        public StudentsController(IDetailsLessonService detailsLessonService,ILessonService lessonService,ITopicSubjectService topicSubjectService,ISubjectService subjectservice, IStudentSubjectService studentSubjectService)
        {
            this.subjectservice=subjectservice;
            this.studentSubjectService=studentSubjectService;
            this.topicSubjectService=topicSubjectService;
            this.lessonService=lessonService;   
            this.detailsLessonService=  detailsLessonService;
        }
        [HttpGet("GetAllSubject")]
        public IActionResult GetAllSubject()
        {
            return Ok(subjectservice.GetAllSubject());
        }
        [HttpGet("GetAllStudentSubject/{IdAccount}")]
        public IActionResult GetAllStudentSubject(int IdAccount)
        {
            if (studentSubjectService.GetALL(IdAccount) == null) return BadRequest();
            return Ok(studentSubjectService.GetALL(IdAccount));
        }
        [HttpGet("FindStudentSubject/{IdAccount},{NameSubject}")]
        public IActionResult FindStudentSubject(int IdAccount , string NameSubject)
        {
            if (studentSubjectService.GetByName(IdAccount, NameSubject) == null) return BadRequest();
            return Ok(studentSubjectService.GetByName(IdAccount, NameSubject));
        }
        [HttpGet("ArrangeStudentSubject/{IdAccount}")]
        public IActionResult ArrangeStudentSubject(int IdAccount)
        {
            if (studentSubjectService.ArraySubject(IdAccount) == null) return BadRequest();
            return Ok(studentSubjectService.ArraySubject(IdAccount));

        }
        [HttpGet("GetFavouritesubject/{IdAccount}")]
        public IActionResult GetStartStudentSubject(int IdAccount)
        {
            if (studentSubjectService.GetStartStudentSubject(IdAccount) == null) return BadRequest();
            return Ok(studentSubjectService.GetStartStudentSubject(IdAccount));

        }
        //[HttpGet("GetDetailsStudentSubject/{IdSubject}")]
        //public IActionResult GetDetailsStudentSubject(int IdSubject)
        //{
        //    if (subjectservice.GetDetail(IdSubject) == null) return BadRequest();
        //    return Ok(subjectservice.GetDetail(IdSubject));
        //}
        [HttpPost("CreateFavouritesubject/{IdSubject},{IdAccount}")]
        public IActionResult CreateFavouritesubject(int IdSubject,int IdAccount)
        {
            if (studentSubjectService.CreateFavouritesubject(IdSubject, IdAccount) == false) return BadRequest();
            return Ok();

        }
        [HttpGet("GetAllTopicSubject/{IdSubject}")]
        public ActionResult GetAllTopicSubject(int IdSubject)
        {
            if (topicSubjectService.GetAllTopicSubject(IdSubject) == null) return BadRequest();

            return Ok(topicSubjectService.GetAllTopicSubject(IdSubject));
        }
        [HttpGet("GetLessonFromTopicSubject/{IdTopic}")]
        public IActionResult GetLessonFromTopicSubject(int IdTopic)
        {
            if (lessonService.GetLesson(IdTopic) == null) return BadRequest();
            return Ok(lessonService.GetLesson(IdTopic));
        }
        [HttpGet("GetAllDetailLesson/{IdLesson}")]

        public IActionResult GetAllDetailLesson(int IdLesson)
        {
            if (detailsLessonService.GetAllDetailLesson(IdLesson) == null) return BadRequest();
            return Ok(detailsLessonService.GetAllDetailLesson(IdLesson));
        }
        [HttpGet("GetDetailsSubject/{IdSubject}")]
        public ActionResult GetDetailsSubject(int IdSubject)
        {
            var a = subjectservice.GetDetailsSubject(IdSubject);
            if (subjectservice.GetDetailsSubject(IdSubject) == null) return BadRequest("Error");
            return Ok(subjectservice.GetDetailsSubject(IdSubject));
        }
    }
}
