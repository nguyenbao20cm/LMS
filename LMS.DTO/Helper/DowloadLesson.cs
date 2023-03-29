using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LMS.DTO.Helper
{
    public interface IFileService
    {
      
      
    
    }
    public class DowloadLesson: IFileService
    {
        private readonly IWebHostEnvironment _environment; 
        private IHostingEnvironment _hostingEnvironment;
        public DowloadLesson(IHostingEnvironment _hostingEnvironment,IWebHostEnvironment _environment)
        {
            this._environment=_environment;
            this._hostingEnvironment = _hostingEnvironment;
        }
        

    }
}
