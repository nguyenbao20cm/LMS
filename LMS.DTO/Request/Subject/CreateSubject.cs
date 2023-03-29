using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Subject
{
    public class CreateSubject
    {
        public string Name { get; set; }
        public string Describe { get; set; }
      /*  public string Status { get; set; }*///1 la phe duyent //2 la chua phe duyejt
        public int Document { get; set; }
    }
}
