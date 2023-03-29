using LMS.DTO.Request.ClassRoom;
using LMS.DTO.Request.DetailExam;
using LMS.DTO.Request.Exam;
using LMS.DTO.Request.StudentSubject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.ComponentModel.DataAnnotations;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        private readonly ITeachingSubjectService _subjectService;
        private readonly IClassRoomService IClassRoomService;
        private readonly ISubjectService ISubjectService;
        private readonly ITeachingSubjectService ITeachingSubjectService;
        private readonly IStudentSubjectService IStudentSubjectService;
        private readonly IExamService examService;
        private readonly IDetailExamService IDetailExamService;
        public LeaderController(IDetailExamService IDetailExamService, IExamService examService, IStudentSubjectService IStudentSubjectService, ISubjectService ISubjectService, IClassRoomService IClassRoomService, ITeachingSubjectService _subjectService)
        {
            this.IDetailExamService = IDetailExamService;
            this.examService = examService;
            this._subjectService = _subjectService;
            this.IClassRoomService = IClassRoomService;
            this.IStudentSubjectService = IStudentSubjectService;
            this.ISubjectService = ISubjectService;
        }
        [HttpGet("GetAllSubject")]
        public IActionResult GetAll()
        {
            return Ok(_subjectService.getALL());

        }
        [HttpPost("CreateClassRoom")]
        public IActionResult CreateClassRoom([FromForm] CreateClassRoomRequest createClassRoomRequest)
        {
            var result = IClassRoomService.Create(createClassRoomRequest);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpGet("GetAllClassRoom")]
        public IActionResult GetAllClassRoom()
        {

            return Ok(IClassRoomService.GetAllClassRoom());

        }
        [HttpPut("UpdateClassRoom/{IdClassRoom}")]
        public IActionResult UpdateClassRoom(int IdClassRoom, [FromForm] CreateClassRoomRequest createClassRoomRequest)
        {
            var result = IClassRoomService.Update(IdClassRoom, createClassRoomRequest);
            if (result == false) return BadRequest();
            return Ok();

        }
        //phe duyet mon hoc
        [HttpPut("ApproveSubject/{IdSubject}")]
        public IActionResult ApproveSubject(int IdSubject)
        {
            var result = ISubjectService.Approve(IdSubject);
            if (result == false) return BadRequest();
            return Ok();

        }
        [HttpPost("CreateTeachingSubject")]
        public IActionResult CreateTeachingSubject([FromForm] CreateTeachingSubject CreateTeachingSubject)
        {
            var result = ITeachingSubjectService.Create(CreateTeachingSubject);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpPost("CreateStudentSubject")]
        public IActionResult CreateStudentSubject([FromForm] CreateStudentSubject CreateStudentSubject)
        {
            var result = IStudentSubjectService.create(CreateStudentSubject);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpPost("CreateExam")]
        public IActionResult CreateExam([FromForm] CreateExam CreateExam)
        {
            var result = examService.Create(CreateExam);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpPut("UpdateExam/{IdExam}")]
        public IActionResult UpdateExam(int IdExam, [FromForm] CreateExam CreateExam)
        {
            var result = examService.Update(IdExam, CreateExam);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpGet("GetAllExam")]
        public IActionResult GetAllExam()
        {
            var result = examService.GetAll();

            return Ok(result);
        }
        [HttpPut("ApproveExam/{IdExam}")]
        public IActionResult ApproveExam(int IdExam)
        {
            var result = examService.Approve(IdExam);
            if (result == false) return BadRequest();
            return Ok();

        }
        [HttpGet("DowloadDetailExam/{filename}")]
        public async Task<IActionResult> DowloadDetailExam([Required] string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Exam", filename);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contentype))
            {
                contentype = "applycation/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contentype, Path.GetFileName(filepath));

        }
        [HttpPost("CreateDetailExam")]
        public IActionResult CreateDetailExam([FromForm] CreateDetailExam CreateStudentSubject)
        {
            var result = IDetailExamService.Create(CreateStudentSubject);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpPut("UpdateDetailExam/{id}")]
        public IActionResult UpdateDetailExam(int id, IFormFile CreateStudentSubject)
        {
            var result = IDetailExamService.Update(id, CreateStudentSubject);
            if (result == false) return BadRequest();
            return Ok();
        }
    }
}
