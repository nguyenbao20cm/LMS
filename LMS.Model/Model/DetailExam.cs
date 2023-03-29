using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class DetailExam
    {
        [Key]
        public int DetailExamID { get; set; }
     
        public int ExamId { get; set; }
        public string NameFile { get; set; }
        public Exam Exam { get; set; }  
    }
}
