using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class TeachingSubject
    {
        [Key]
        public int TeachingSubjectId { get; set; }
        public int AccountID { get; set; }
        
        public Account Account { get; set; }
        public int ClassRoomID { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

    }
}
