using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.StudentSubject
{
    public class CreateStudentSubject
    {
      
        public int StudentSubjectId { get; set; }

        public int AccountID { get; set; }

        public int AccountTeacherId { get; set; }

        public int ClassRoomID { get; set; }
     
        public int SubjectID { get; set; }
    
        public bool Start { get; set; }
    }
}
