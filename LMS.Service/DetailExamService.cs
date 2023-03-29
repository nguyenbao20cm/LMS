using LMS.DTO.Request.DetailExam;
using LMS.Model.Model;
using LMS.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LMS.Service
{
    public interface IDetailExamService
    {
        public bool Update(int id, IFormFile exam);
        public bool Create(CreateDetailExam exam);
    }
    public class DetailExamService : IDetailExamService
    {
        private readonly IDetailExamRepositories IDetailExamRepositories;
        private readonly IWebHostEnvironment _environment;
        public DetailExamService(IWebHostEnvironment _environment,IDetailExamRepositories IDetailExamRepositories)
        {
            this.IDetailExamRepositories=IDetailExamRepositories;
            this._environment = _environment;
        }
        public bool Create(CreateDetailExam exam)
        {    if (exam == null) return false;
            var fileName = exam.NameFile.FileName;
            var uploadFolder = Path.Combine(_environment.WebRootPath, "Exam");
            var uploadPath = Path.Combine(uploadFolder, fileName);

            using (FileStream fs = System.IO.File.Create(uploadPath))
            {
                exam.NameFile.CopyTo(fs);
                fs.Flush();
            }
            DetailExam result = new();
            result.NameFile = exam.NameFile.FileName;
            result.ExamId = exam.ExamId;
            return IDetailExamRepositories.Create(result);
        }
        public bool Update(int id,IFormFile exam)
        {
            if (exam == null) return false;
            var fileName = exam.FileName;
            var uploadFolder = Path.Combine(_environment.WebRootPath, "Exam");
            var uploadPath = Path.Combine(uploadFolder, fileName);

            using (FileStream fs = System.IO.File.Create(uploadPath))
            {
                exam.CopyTo(fs);
                fs.Flush();
            }
            DetailExam result = IDetailExamRepositories.GetByid(id);
            result.NameFile = exam.FileName;
        
            return IDetailExamRepositories.Update(result);
        }
    }
}
