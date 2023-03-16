using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Subject
{
    public class SubjectDetails___
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Desc { get; set; }

        public string Status { get; set; }
        public int Document { get; set; }
        List<DetailsSubject> detailsSubjects { get; set; }
    }
}
