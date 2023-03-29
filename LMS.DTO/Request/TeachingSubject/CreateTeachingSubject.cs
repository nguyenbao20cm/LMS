using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.TeachingSubject
{
    public class CreateTeachingSubject
    {
       

        public int AccountID { get; set; }

        public int ClassRoomID { get; set; }
     
        public int SubjectID { get; set; }
      
    }
}
