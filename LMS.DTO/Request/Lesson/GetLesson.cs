using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Lesson
{
    public class GetLesson
    {
       
        public string Title { get; set; }
        public string Describe { get; set; }
        public string Content { get; set; }
        public int ClassRoomId { get; set; }
        public int TopicSubjectId { get; set; }
      
    }
}
