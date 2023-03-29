using LMS.DTO.Request.Exam;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface IExamService
    {
        public bool Approve(int id);
        public List<GetAllExam> GetAll();
        public bool Create(CreateExam exam);
        public bool Update(int id, CreateExam exam);
    }
    public class ExamService : IExamService
    {
        private readonly IExamRepositories examRepositories;
        private readonly ITaiKhoanRepository ITaiKhoanRepository;
        public ExamService(ITaiKhoanRepository ITaiKhoanRepository,IExamRepositories examRepositories   )
        {
            this.examRepositories=examRepositories;
            this.ITaiKhoanRepository = ITaiKhoanRepository;
        }
        public bool Create(CreateExam exam)
        {
            Exam a = new();
            a.dateTime = exam.dateTime;
            a.Time = exam.Time;
            a.Category=exam.Category;
            a.Name = exam.Name;
            a.Subjcet = exam.Subjcet;
            a.Form = exam.Form;
            a.TeacherId = exam.TeacherId;
            a.Status = exam.Status;
            return examRepositories.Create(a);
        }
        public bool Update(int id ,CreateExam exam)
        {
            Exam a = examRepositories.GetById(id);
            a.dateTime = exam.dateTime;
            a.Time = exam.Time;
            a.Category = exam.Category;
            a.Name = exam.Name;
            a.Subjcet = exam.Subjcet;
            a.Form = exam.Form;
            a.TeacherId = exam.TeacherId;
            a.Status = exam.Status;
            return examRepositories.Update(a);
        }
        public bool Approve(int id)
        {
            Exam a = examRepositories.GetById(id);
            a.Status = 1;
            return examRepositories.Update(a);
        }
        public List<GetAllExam> GetAll()
        {
            var a = examRepositories.GetAll();
            List<GetAllExam> result = new();

            foreach (var item in  a)
            {
                GetAllExam tamp = new();
                tamp.ExamId=item.ExamId;
                tamp.Category = item.Category;
                tamp.Name = item.Name;
                tamp.Subjcet = item.Subjcet;
                tamp.Form = item.Form;
                tamp.Time = item.Time;
                tamp.TeacherName = ITaiKhoanRepository.GetById(item.TeacherId).TenNguoiDung;
                tamp.dateTime = item.dateTime; 
                tamp.Status = item.Status;
                result.Add(tamp);
            }

            return result;
        }
    }
}
