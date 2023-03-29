using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoomId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Describe { get; set; }
        public ICollection<TeachingSubject> TeachingSubject { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
