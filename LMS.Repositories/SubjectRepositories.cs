using LMS.Context;
using LMS.DTO.Request.Subject;
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
    public interface ISubjectRepositories
    {
        bool create(Subject Subject);
        bool update(Subject Subject);
        public List<Subject> GetAll();
        public Subject GetDetailsSubject(int id);
        public bool Approve(Subject Subject);

    }
    public class SubjectRepositories : ISubjectRepositories
    {
        private readonly AppDbContext context;
        public SubjectRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool Approve(Subject Subject)
        {
            context.Subject.Update(Subject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool create(Subject Subject)
        {
            context.Subject.Add(Subject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public List<Subject> GetAll()
        {
            return context.Subject.ToList();
        }

     

        public bool update(Subject Subject)
        {
            throw new NotImplementedException();
        }
        public Subject GetDetailsSubject(int IdSubject)
        {
            var a = context.Subject.Where(x => x.SubjectId == IdSubject).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            
            return a;

        }
    }
}
