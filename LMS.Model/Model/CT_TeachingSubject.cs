using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class CT_TeachingSubject
    {
        [Key]
        public int CT_TeachingSubjectId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectID { get; set; }    
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomID { get; set; }
        public TeachingSubject TeachingSubject { get; set; }
        public int TeachingSubjectID { get; set; }
    }
}
