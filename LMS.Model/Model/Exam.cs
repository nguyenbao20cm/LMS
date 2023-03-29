using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Model
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int Category { get; set; }// 1 la word // 2 la exel//3 la pdf
        public string Name { get; set; }
        public string Subjcet { get; set; }
        public int Form { get; set; }//1 la trac nghiem 2 la tu luan

        public string Time { get; set; }
        public int TeacherId { get; set; }
        public Account Teacher { get; set; }
        public DateTime dateTime { get; set; }

        public int Status { get; set; }//1 la phe duyet//2 la chua
        public ICollection<DetailExam> DetailExam { get; set; }


    }
}
