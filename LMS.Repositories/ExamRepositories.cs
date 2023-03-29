using LMS.Context;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface IExamRepositories
    {
        public bool Approve(Exam exam);
        public bool Update(Exam exam);
        public Exam GetById(int id);
        bool Create(Exam exam);
        public List<Exam> GetAll();
    }
    public class ExamRepositories : IExamRepositories
    {
        private readonly AppDbContext context;
        public ExamRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public Exam GetById(int id)
        {
            return context.Exam.Where(a => a.ExamId == id).FirstOrDefault();
        }
        public bool Create(Exam exam)
        {
            context.Add(exam);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool Approve(Exam exam)
        {
            context.Update(exam);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool Update(Exam exam)
        {
            context.Update(exam);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public List<Exam> GetAll()
        {
          return  context.Exam.ToList();
         
        }
    }
}
