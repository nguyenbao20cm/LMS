using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string Status { get; set; }//1 la phe duyent //2 la chua phe duyejt
        public int Document { get; set; }
       
        public ICollection<TeachingSubject> TeachingSubject { get; set; }
        public ICollection<DetailsSubject> DetailsSubject { get; set; }
        public ICollection<TopicSubject> TopicSubject { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
