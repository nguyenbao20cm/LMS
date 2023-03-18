using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Describe { get; set; }
        public string Content    { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int TopicSubjectId { get; set; }
        public TopicSubject TopicSubject { get; set; }
        public ICollection<DetailsLesson> DetailsLesson { get; set; }
    }
}
