using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class DetailsSubject
    {
        [Key]
        public int DetailsSubjectId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string   Title { get; set; }
        public string Content { get; set; }

    }
}
