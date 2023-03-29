using LMS.DTO.Request.DetailLesson;
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

namespace LMS.Service
{
    public interface IDetailsLessonService
    {
        public List<GetDetailLesson> GetAllDetailLesson(int Idlesson);
        public bool CreateDetailLesson(int Idlesson, int IdAcc, string Name1, IFormFile DetailsLessons);
    }
    public class DetailsLessonService: IDetailsLessonService
    {
        private readonly IDetailsLessonRepositories IDetailsLessonRepositories;
        private readonly ITaiKhoanRepository TaikhoanRepositories;
        private readonly IWebHostEnvironment _environment;
       
        public DetailsLessonService( IDetailsLessonRepositories IDetailsLessonRepositories,ITaiKhoanRepository TaikhoanRepositories,IWebHostEnvironment _environment)
        {
            this.TaikhoanRepositories = TaikhoanRepositories;
            this._environment = _environment;
            this.IDetailsLessonRepositories = IDetailsLessonRepositories;
            
          
        }
        public List<GetDetailLesson> GetAllDetailLesson(int Idlesson)
        {
            var a = IDetailsLessonRepositories.GetAllDetailLesson(Idlesson);
            if (a == null) return null;

            List<GetDetailLesson> result = new();
            GetDetailLesson temp = new();
            foreach (var item in a)
            {
                GetDetailLesson tam = new();
                tam.Name = item.Name;
                tam.Type = item.Type;
                tam.NameAccount = item.NameAccount;

                tam.CreatedDate = item.CreatedDate;
                tam.Size = item.Size;
                result.Add(tam);
            }
            return result;

        }
        public bool CreateDetailLesson(int Idlesson, int IdAcc, string Name1, IFormFile DetailsLessons)
        {
            int check = 0;

            var fileName = DetailsLessons.FileName;
            var uploadFolder = Path.Combine(_environment.WebRootPath, "Document", "Lesson");
            var uploadPath = Path.Combine(uploadFolder, fileName);
            using (FileStream fs = System.IO.File.Create(uploadPath))
            {
                DetailsLessons.CopyTo(fs);
                fs.Flush();
            }

            FileInfo ab = new FileInfo(uploadPath);
            DetailsLesson result = new();
            result.Name = Name1;
            result.Type = DetailsLessons.ContentType;
            result.CreatedDate = DateTime.Now;
            result.NameAccount = TaikhoanRepositories.GetById(IdAcc).TenNguoiDung;
            result.Size = ab.Length;
            result.LessonId = Idlesson;

            return IDetailsLessonRepositories.create(result);
        }
    }
}
