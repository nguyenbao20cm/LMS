using LMS.Context;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface IStudentSubjectRepositories
    {
        bool create(StudentSubject StudentSubject);

        public List<StudentSubject> ArraySubject(int id);
        bool update(Lesson Lesson);
        List<StudentSubject> GetAll(int Id);
        public StudentSubject GetByName(int IdAcc, string NameSubject);
        public List<StudentSubject> GetStartStudentSubject(int id);
        bool CreateFavouritesubject(int IdSubject, int IdAccount);

    }
    public class StudentSubjectRepositories : IStudentSubjectRepositories
    {
        private readonly AppDbContext context;
        public StudentSubjectRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool create(StudentSubject StudentSubject)
        {
            context.Add(StudentSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
       
        public List<StudentSubject> GetAll(int id)
        {
            var a = context.StudentSubject.
                    Include(c => c.ClassRoom)
                    .Include(c => c.Subject).
                    Include(c => c.Account).Where(c => c.AccountID == id).ToList();
            if (a != null)
            {
                return a;
            }
            else
            {
                return null;
            }
        }

        public bool update(Lesson Lesson)
        {
            throw new NotImplementedException();
        }
        public StudentSubject GetByName(int IdAcc, string NameSubject)
        {
            var a = context.StudentSubject.
                Include(c => c.ClassRoom)
                .Include(c => c.Subject).
                Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                .Where(c => c.Subject.Name.Contains(NameSubject)).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            else
            {
                return a;
            }
        }

        public List<StudentSubject> ArraySubject(int id)
        {
            var a = context.StudentSubject.
                 Include(c => c.ClassRoom)
                 .Include(c => c.Subject).
                 Include(c => c.Account).Where(c => c.AccountID == id)
                 .OrderBy(c => c.Subject.Name)
                 .ToList();
            if (a == null) return null;
            return a;
        }

        public List<StudentSubject> GetStartStudentSubject(int id)
        {
            var a = context.StudentSubject.
                              Include(c => c.ClassRoom)
                              .Include(c => c.Subject).
                              Include(c => c.Account).Where(c => c.AccountID == id).Where(c=>c.Start==true).ToList();
            if (a == null) return null;
            return a;
        }

        public bool CreateFavouritesubject(int IdSubject,int IdAccount)
        {
            var a = context.StudentSubject.Where(c => c.AccountID == IdAccount).Where(c=>c.SubjectID==IdSubject).FirstOrDefault();
            if (a == null) return false;
            a.Start = true;
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
    }
}
