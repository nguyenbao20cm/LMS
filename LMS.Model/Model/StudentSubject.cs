using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class StudentSubject
    {
        [Key]
        public int StudentSubjectId { get; set; }
        public int AccountID { get; set; }
        public int AccountTeacherId { get; set; }
        public Account Account { get; set; }
        public int ClassRoomID { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public bool Start { get; set; }
       
        
    }
}
