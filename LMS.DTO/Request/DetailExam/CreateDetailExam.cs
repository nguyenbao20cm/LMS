using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.DetailExam
{
    public class CreateDetailExam
    {
     
        public int ExamId { get; set; }
        public IFormFile NameFile { get; set; }
       
    }
}
