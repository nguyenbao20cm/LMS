using LMS.Model.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DTO.Request.Lesson
{
    public class UpdateLesson
    {
        
      
        public string Title { get; set; }
        public string Describe { get; set; }
        public IFormFile Content { get; set; }

      
    }
}
