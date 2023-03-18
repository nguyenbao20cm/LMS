using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class DetailsLesson
    {
        [Key]
        public int DetailsLessonId { get; set; }    
        public string Name { get; set; }
        public string Type { get; set; }
        public string NameAccount { get; set; }
        public  DateTime  CreatedDate { get; set; }
        public long Size { get; set; }   
        public int LessonId { get; set; }
        public Lesson lesson { get; set; }

    }
}
