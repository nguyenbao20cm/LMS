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
        public string Status { get; set; }
        public int Document { get; set; }
     
        public ICollection<TeachingSubject> TeachingSubject { get; set; }
    }
}
