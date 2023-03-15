using LMS.Context;
using LMS.DTO.Request.AccountRequest;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface ITeacherRepositories
    {
        Subject GetById(int id);
        bool UpdateDetailTeacherSubject(Subject detailsSubject);
        bool CheckID(int id);
        Task<ActionResult<DetailsSubject>> GetDetailsSubject(int id);
        List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject);// Tim theo ma
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc,string NameTeacherSubject);// Tim theo ten
        List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int id);// Tim theo ten
    }
    public class TeacherRepositories: ITeacherRepositories
    {
        private readonly AppDbContext context;
      
        public TeacherRepositories(AppDbContext context)
        {
            this.context = context;
            
        }

        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc,int IdTeacherSubject)
        {
            var a = context.TeachingSubject.
                    Include(c => c.ClassRoom)
                    .Include(c => c.Subject).
                    Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                    .Where(c=>c.SubjectID==IdTeacherSubject).FirstOrDefault();
            TeachingSubjectGetAll temp = new();
            temp.SubjectId = a.SubjectID;
            temp.SubjectName = a.Subject.Name;
            temp.Desc = a.Subject.Describe;
            temp.Status = a.Subject.Status;
            temp.Document = a.Subject.Document;
            return temp;
        }

        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc,string NameTeacherSubject)
        {
            var a = context.TeachingSubject.
                     Include(c => c.ClassRoom)
                     .Include(c => c.Subject).
                     Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                     .Where(c => c.Subject.Name.Contains(NameTeacherSubject)).FirstOrDefault();
            TeachingSubjectGetAll temp = new();
            temp.SubjectId = a.SubjectID;
            temp.SubjectName = a.Subject.Name;
            temp.Desc = a.Subject.Describe;
            temp.Status = a.Subject.Status;
            temp.Document = a.Subject.Document;
            return temp;
        }

        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            var a = context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).Where(c => c.AccountID == id).ToList();
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

        public async Task<ActionResult<DetailsSubject>> GetDetailsSubject(int id)
        {
            var a= await context.Subject.Where(x => x.SubjectId == id).FirstAsync();

         
          
                DetailsSubject result = new();
                result.SubjectId = a.SubjectId;
                result.SubjectName = a.Name;
                result.Document=a.Document;
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
            return context.Subject.Where(x => x.SubjectId == id).FirstOrDefault();
        }
        public bool UpdateDetailTeacherSubject(Subject detailsSubject)
        {
            context.Subject.Update(detailsSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
    }
}
