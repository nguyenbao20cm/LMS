using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public  class TopicSubject
    {
        [Key]
        public int TopicSubjectId { get; set; }
        public string NameTopicSubject { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Lesson> Lesson { get; set; }

    }
}
