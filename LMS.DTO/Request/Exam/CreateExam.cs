using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Exam
{
    public class CreateExam
    {
       
        public int Category { get; set; }// 1 la word // 2 la exel//3 la pdf
        public string Name { get; set; }
        public string Subjcet { get; set; }
        public int Form { get; set; }//1 la trac nghiem 2 la tu luan

        public string Time { get; set; }
        public int TeacherId { get; set; }
    
        public DateTime dateTime { get; set; }

        public int Status { get; set; }//1 la phe duyet//2 la chua
     
    }
}
