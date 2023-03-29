using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.ClassRoom
{
    public class CreateClassRoomRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Describe { get; set; }
    }
}
