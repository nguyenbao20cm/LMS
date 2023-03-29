using LMS.DTO.Request.ClassRoom;
using LMS.DTO.Request.StudentSubject;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public LeaderController(IStudentSubjectService IStudentSubjectService,ISubjectService ISubjectService,IClassRoomService IClassRoomService,ITeachingSubjectService _subjectService)
        {
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
        public IActionResult CreateClassRoom([FromForm]CreateClassRoomRequest createClassRoomRequest)
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
    }
}
