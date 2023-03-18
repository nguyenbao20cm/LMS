using LMS.Context;
using LMS.DTO.Request.ClassRoom;
using LMS.DTO.Request.DetailLesson;
using LMS.DTO.Request.Lesson;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.DTO.Request.TopicSubject;
using LMS.Model.Migrations;
using LMS.Model.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace LMS.Repositories
{
    public interface ITeacherRepositories
    {
        bool CreateDetailLesson(int Idlesson, int IdAcc, string Name1, IFormFile DetailsLesson);
        bool UpdateDetailLesson(int Id, string Name1, IFormFile DetailsLesson);
        List<GetDetailLesson> GetAllDetailLesson(int Idlesson);
        GetLesson GetLesson(int id);
        List<GetAllClassRoom> GetAllClassRoom( );
        bool CreateLesson(CreateLesson Lesson);
        bool UpdateLesson(int id, UpdateLesson Lesson);
        bool UpdateTopicSubject(TopicSubject UpdateTopicSubject);
        List<GetAllTopicSubject> GetAllTopicSubject(int id);
        List<GetAllSubject> GetAllSubject( );
        bool CreateTopicSubject(TopicSubject TopicSubject);
        bool UpdateInformationDetailSubject(DetailsSubject DetailsSubject);
        bool DeleteInformationDetailSubject(int id);
        bool CheckIdSubject(int id);
        bool CreateInformationDetailSubject(DetailsSubject DetailsSubject);
        List<DetailsSubject> DetailsSubject(int id);
        Subject GetById(int id);
        bool UpdateDetailTeacherSubject(Subject detailsSubject);
        bool CheckID(int id);
        DetailsSubjectRequest GetDetailsSubject(int IdSubject);
        List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject);// Tim theo ma
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject);// Tim theo ten
        List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int id);// Tim theo ten
    }
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _environment;
        public TeacherRepositories(AppDbContext context, IWebHostEnvironment _environment)
        {
            this.context = context;
            this._environment = _environment;
        }
        
       
        public GetLesson GetLesson(int id)
            
        {
            var a= context.Lesson.Where(a => a.TopicSubjectId == id).FirstOrDefault();
            if (a == null) return null;
            GetLesson result = new();
            result.Title = a.Title;
            result.Content = a.Content;
            result.Describe = a.Describe;
            result.ClassRoomId = a.ClassRoomId;
            result.TopicSubjectId = a.TopicSubjectId;
            return result;
        }
      
        public bool CheckIdSubject(int id)
        {
            var a = context.Subject.Where(x => x.SubjectId == id).FirstOrDefault();
            if (a != null)
                return true;
            else return false;
        }
        public List<GetAllClassRoom> GetAllClassRoom()
        {
            var a= context.ClassRoom.ToList();
           List< GetAllClassRoom >result = new();
             foreach (var item in a)
            {
                GetAllClassRoom tam = new();
                tam.ClassRoomId = item.ClassRoomId;
                tam.Name = item.Name;
                tam.Quantity = item.Quantity;
                tam.Describe = item.Describe;
                result.Add(tam);
            }
            return result;
        }
     
        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject)
        {
            var a = context.TeachingSubject.
                    Include(c => c.ClassRoom)
                    .Include(c => c.Subject).
                    Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                    .Where(c => c.SubjectID == IdTeacherSubject).FirstOrDefault();
            if (a == null)
            {
                TeachingSubjectGetAll temp = null;
                return temp;
            }
            else
            {
                TeachingSubjectGetAll temp = new();
                temp.SubjectId = a.SubjectID;
                temp.SubjectName = a.Subject.Name;
                temp.Desc = a.Subject.Describe;
                temp.Status = a.Subject.Status;
                temp.Document = a.Subject.Document;
                return temp;
            }
        }

        public bool UpdateTopicSubject(TopicSubject UpdateTopicSubject)
        {
            var a = context.TopicSubject.Where(a => a.TopicSubjectId == UpdateTopicSubject.TopicSubjectId).FirstOrDefault();
            a.NameTopicSubject = UpdateTopicSubject.NameTopicSubject;
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public List<GetAllTopicSubject> GetAllTopicSubject(int id)
        {
            var a = context.TopicSubject.Where(a=>a.SubjectId==id).ToList();
            List<GetAllTopicSubject> result = new();

            foreach (var item in a)
            {
                GetAllTopicSubject tam = new();
                tam.NameTopicSubject = item.NameTopicSubject;
                result.Add(tam);
            }

            return result;

        }
        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject)
        {

            var a = context.TeachingSubject.
                 Include(c => c.ClassRoom)
                 .Include(c => c.Subject).
                 Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                 .Where(c => c.Subject.Name.Contains(NameTeacherSubject)).FirstOrDefault();
            if (a == null)
            {
                TeachingSubjectGetAll temp = null;
                return temp;
            }
            else
            {
                TeachingSubjectGetAll temp = new();
                temp.SubjectId = a.SubjectID;
                temp.SubjectName = a.Subject.Name;
                temp.Desc = a.Subject.Describe;
                temp.Status = a.Subject.Status;
                temp.Document = a.Subject.Document;
                return temp;
            }


        }
        public List<GetAllSubject> GetAllSubject()
        {
            var a = context.Subject.ToList();
            List<GetAllSubject> result = new();
          
            foreach (var item in a)
            {
                GetAllSubject tam = new();
                tam.SubjectId = item.SubjectId;
                tam.Name = item.Name;
                tam.Describe = item.Name;
                tam.Describe = item.Describe;
                tam.Status = item.Status;
                tam.Document = item.Document;
                result.Add(tam);
            }
          
            return result;
          
        }
        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            var a = context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).Where(c => c.AccountID == id).ToList();
            if (a != null)
            {
                List<TeachingSubjectGetAll> result = new();
                TeachingSubjectGetAll temp = new();
                foreach (var item in a)
                {
                    TeachingSubjectGetAll tam = new();
                    tam.SubjectId = item.SubjectID;
                    tam.SubjectName = item.Subject.Name;
                    tam.Desc = item.Subject.Describe;
                    tam.Status = item.Subject.Status;
                    tam.Document = item.Subject.Document;
                    result.Add(tam);
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public DetailsSubjectRequest GetDetailsSubject(int IdSubject)
        {
            var a = context.Subject.Where(x => x.SubjectId == IdSubject).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            DetailsSubjectRequest result = new();
            result.SubjectId = a.SubjectId;
            result.SubjectName = a.Name;
            result.Document = a.Document;
            result.Status = a.Status;
            result.Desc = a.Describe;
            return result;

        }
        public bool CheckID(int id)
        {
            var check = context.TaiKhoan.Where(x => x.TaiKhoanId == id).FirstOrDefault();
            if (check == null) return false;
            else return true;
        }

        public List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int IdAcc)
        {
            var a = context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                   .OrderBy(c => c.Subject.Name)
                   .ToList();
            List<TeachingSubjectGetAll> result = new();
            TeachingSubjectGetAll temp = new();
            foreach (var item in a)
            {
                TeachingSubjectGetAll tam = new();
                tam.SubjectId = item.SubjectID;
                tam.SubjectName = item.Subject.Name;
                tam.Desc = item.Subject.Describe;
                tam.Status = item.Subject.Status;
                tam.Document = item.Subject.Document;
                result.Add(tam);
            }
            return result;
        }
        public Subject GetById(int id)
        {
            if (context.Subject.Where(x => x.SubjectId == id).FirstOrDefault() == null)
            {
                Subject temp = null;
                return temp;
            }
            else
            {
                return context.Subject.Where(x => x.SubjectId == id).FirstOrDefault();
            }
        }
        public bool UpdateDetailTeacherSubject(Subject detailsSubject)
        {
            context.Subject.Update(detailsSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public List<DetailsSubject> DetailsSubject(int id)
        {
            var a = context.DetailsSubject.Where(a => a.SubjectId == id).ToList();
            if (a == null)
            {
                return null;
            }
            else
                return context.DetailsSubject.Where(a => a.SubjectId == id).ToList();
        }
        public bool CreateInformationDetailSubject(DetailsSubject DetailsSubject)
        {
            context.DetailsSubject.Add(DetailsSubject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool UpdateInformationDetailSubject(DetailsSubject DetailsSubject)
        {
            context.DetailsSubject.Update(DetailsSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool DeleteInformationDetailSubject(int id)
        {

            context.DetailsSubject.Remove(context.DetailsSubject.Where(i => i.DetailsSubjectId == id).FirstOrDefault());

            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public bool CreateTopicSubject(TopicSubject TopicSubject)
        {
            context.TopicSubject.Add(TopicSubject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public bool CreateLesson(CreateLesson clr)
        {

            
            int check = 0;
            if (clr.Content != null)
            {
                var fileName = clr.Content.FileName;
                var uploadFolder = Path.Combine(_environment.WebRootPath, "Video", "Lesson");
                var uploadPath = Path.Combine(uploadFolder, fileName);
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    clr.Content.CopyTo(fs);
                    fs.Flush();
                }

                Lesson result = new();
                result.Title = clr.Title;
                result.Describe = clr.Describe;
                result.Content = fileName;
                result.ClassRoomId = clr.ClassRoomId;
                result.TopicSubjectId = clr.TopicSubjectId;


                context.Lesson.Add(result);
                check = context.SaveChanges();
            }
            return check > 0 ? true : false;
        }

        public bool UpdateLesson(int id,UpdateLesson clr)
        {

            int check = 0;
            if (clr.Content != null)
            {
                var fileName = clr.Content.FileName;
                var uploadFolder = Path.Combine(_environment.WebRootPath, "Video", "Lesson");
                var uploadPath = Path.Combine(uploadFolder, fileName);
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    clr.Content.CopyTo(fs);
                    fs.Flush();
                }

                var result = context.Lesson.Where(a => a.LessonId == id).FirstOrDefault();


                result.Title = clr.Title;
                result.Describe = clr.Describe;
                result.Content = fileName;
          


                context.Lesson.Update(result);
                check = context.SaveChanges();
            }
            return check > 0 ? true : false;
        }

        public bool CreateDetailLesson(int Idlesson,int IdAcc,string Name1,IFormFile DetailsLesson)
        {
            
                int check = 0;

                var fileName = DetailsLesson.FileName;
                var uploadFolder = Path.Combine(_environment.WebRootPath, "Document", "Lesson");
                var uploadPath = Path.Combine(uploadFolder, fileName);
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    DetailsLesson.CopyTo(fs);
                    fs.Flush();
                }
            
     FileInfo ab = new FileInfo(uploadPath);
                DetailsLesson result = new();
               result.Name = Name1;
            result.Type = DetailsLesson.ContentType;
            result.CreatedDate = DateTime.Now;
            result.NameAccount = context.TaiKhoan.Where(a=>a.TaiKhoanId==IdAcc).FirstOrDefault().TenDangNhap;
            result.Size = ab.Length;
            result.LessonId = Idlesson;
            context.DetailsLesson.Add(result);
                check = context.SaveChanges();

                return check > 0 ? true : false;
        }

        public bool UpdateDetailLesson(int id, string Name1, IFormFile DetailsLesson)
        {
            int check = 0;
            
            var fileName = DetailsLesson.FileName;
            var uploadFolder = Path.Combine(_environment.WebRootPath, "Document", "Lesson");
            var uploadPath = Path.Combine(uploadFolder, fileName);
            using (FileStream fs = System.IO.File.Create(uploadPath))
            {
                DetailsLesson.CopyTo(fs);
                fs.Flush();
            }

            FileInfo ab = new FileInfo(uploadPath);
            var result = context.DetailsLesson.Where(a => a.DetailsLessonId == id).FirstOrDefault();
            result.Name = Name1;
            result.Type = DetailsLesson.ContentType;
            result.CreatedDate = DateTime.Now;
          
            result.Size = ab.Length;
           
            context.DetailsLesson.Update(result);
            check = context.SaveChanges();

            return check > 0 ? true : false;
        }

        public List<GetDetailLesson> GetAllDetailLesson(int Idlesson)
        {
            var a = context.DetailsLesson.Where(a => a.LessonId == Idlesson).ToList();
           
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
    }
}


