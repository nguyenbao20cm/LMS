using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Subject
{
    public class DetailsSubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Desc { get; set; }

        public string Status { get; set; }
        public int Document { get; set; }
    }
}
