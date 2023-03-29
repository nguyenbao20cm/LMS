using LMS.Context;
using LMS.DTO.Request.AccountRequest;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface IDetailExamRepositories
    {
        public bool Create(DetailExam exam);
        public DetailExam GetByid(int id);
        public bool Update(DetailExam exam);


    }
    public class DetailExamRepositories : IDetailExamRepositories
    {
        private readonly AppDbContext context;
        public DetailExamRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public DetailExam GetByid(int id)
        {

            return context.DetailExam.Where(a => a.DetailExamID == id).FirstOrDefault();
        }
        public bool Update(DetailExam exam)
        {

            context.Update(exam);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool Create(DetailExam exam)
        {
            context.Add(exam);
            try
            {
                var check = context.SaveChanges();
                return check > 0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
            
           
        }
    }
}
