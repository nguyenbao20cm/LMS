using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.DetailLesson
{
    public class GetDetailLesson
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string NameAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Size { get; set; }
 
    }
}
