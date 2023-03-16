using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Subject
{
    public class AddDetailsSubject
    {
        public int SubjectId { get; set; }
      
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
