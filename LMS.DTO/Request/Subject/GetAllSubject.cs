using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Subject
{
    public class GetAllSubject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string Status { get; set; }
        public int Document { get; set; }
    }
}
