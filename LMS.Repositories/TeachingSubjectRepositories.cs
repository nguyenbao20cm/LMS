using LMS.Context;
using LMS.Model.Migrations;
using LMS.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface ITeachingSubjectRepositories
    {
        bool Create(TeachingSubject TeachingSubject);
        bool update(TeachingSubject TeachingSubject);
        List<TeachingSubject> GetAll();

    }
    public class TeachingSubjectRepositories : ITeachingSubjectRepositories
    {
        private readonly AppDbContext context;
        public TeachingSubjectRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool Create(TeachingSubject TeachingSubject)
        {
            context.Add(TeachingSubject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
           
        }

        public List<TeachingSubject> GetAll()
        {
            if (context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).ToList() == null) return null;
            return context.TeachingSubject.ToList();
        }

        public bool update(TeachingSubject TeachingSubject)
        {
            throw new NotImplementedException();
        }
    }
}
