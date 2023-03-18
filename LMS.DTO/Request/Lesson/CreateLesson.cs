using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Lesson
{
    public class CreateLesson
    {
      
        public string Title { get; set; }
        public string Describe { get; set; }
        public IFormFile Content { get; set; }
        public int ClassRoomId { get; set; }
        public int TopicSubjectId { get; set; }
      
    }
}
