using LMS.DTO.Request.StudentSubject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Migrations;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{   
    public interface IStudentSubjectService
    {
        public bool CreateFavouritesubject(int ida, int idsubject);
        public List<GetStudentSubject> GetStartStudentSubject(int id);
        public bool create(CreateStudentSubject createStudentSubject);
        GetStudentSubject GetByName(int IdAcc, string NameSubject);
        public List<GetStudentSubject> GetALL(int id);
        public List<GetStudentSubject> ArraySubject(int id);
    }

    public class StudentSubjectService : IStudentSubjectService
        
    {
        private readonly ITaiKhoanRepository taiKhoanRepository;
        private readonly IStudentSubjectRepositories studentSubjectRepositories;
        public StudentSubjectService(ITaiKhoanRepository taiKhoanRepository,IStudentSubjectRepositories studentSubjectRepositories)
        {
            this.studentSubjectRepositories = studentSubjectRepositories;
            this.taiKhoanRepository = taiKhoanRepository;
        }
        public List<GetStudentSubject> GetStartStudentSubject(int id)
        {
            var a = studentSubjectRepositories.GetStartStudentSubject(id);
            List<GetStudentSubject> result = new();
            if (a == null)
            {
                return null;
            }
            else
            {
                foreach (var item in a)
                {
                    GetStudentSubject tam = new();
                    tam.SubjectId = item.SubjectID;
                    tam.SubjectName = item.Subject.Name;
                    tam.Desc = item.Subject.Describe;
                    tam.Start = item.Start;
                    tam.NameTeacher = taiKhoanRepository.GetById(item.AccountTeacherId).TenNguoiDung;
                    tam.Status = item.Subject.Status;
                    tam.Document = item.Subject.Document;
                    result.Add(tam);
                }
                return result;
            }
        }
        public List<GetStudentSubject> ArraySubject(int id)
        {
            var a = studentSubjectRepositories.ArraySubject(id);
            if (a == null) return null;
            List<GetStudentSubject> result = new();
            GetStudentSubject temp = new();
            foreach (var item in a)
            {
                GetStudentSubject tam = new();
                tam.SubjectId = item.SubjectID;
                tam.SubjectName = item.Subject.Name;
                tam.Desc = item.Subject.Describe;
                tam.Start = item.Start;
                tam.NameTeacher = taiKhoanRepository.GetById(item.AccountTeacherId).TenNguoiDung;
                tam.Status = item.Subject.Status;
                tam.Document = item.Subject.Document;
                result.Add(tam);
            }
            return result;
        }
        public GetStudentSubject GetByName(int IdAcc, string NameSubject)
        {
            var a= studentSubjectRepositories.GetByName(IdAcc, NameSubject);
            if (a == null)
            {
                GetStudentSubject temp = null;
                return temp;
            }
            else
            {
                GetStudentSubject temp = new();
                temp.SubjectId = a.SubjectID;
                temp.SubjectName = a.Subject.Name;
                temp.Start = a.Start;
                temp.NameTeacher = taiKhoanRepository.GetById(a.AccountTeacherId).TenNguoiDung; 
                temp.Desc = a.Subject.Describe;
                temp.Status = a.Subject.Status;
                temp.Document = a.Subject.Document;
                return temp;
            }
        }

        public bool create(CreateStudentSubject createStudentSubject)
        {
            StudentSubject result = new();
            result.AccountID=createStudentSubject.AccountID;
            result.AccountTeacherId=createStudentSubject.AccountTeacherId;  
            result.ClassRoomID=createStudentSubject.ClassRoomID;
            result.SubjectID=createStudentSubject.SubjectID;
            result.Start=createStudentSubject.Start;
            return studentSubjectRepositories.create(result);
        }

        public List<GetStudentSubject> GetALL(int id)
        {
            var a = studentSubjectRepositories.GetAll(id);
            if (a == null) return null;
            List<GetStudentSubject> result = new();
            GetStudentSubject temp = new();
            foreach (var item in a)
            {
                GetStudentSubject tam = new();
                tam.SubjectId = item.SubjectID;
                tam.SubjectName = item.Subject.Name;
                tam.Desc = item.Subject.Describe;
                tam.Status = item.Subject.Status;
                tam.Start = item.Start;
                tam.Document = item.Subject.Document;
                tam.NameTeacher = taiKhoanRepository.GetById(item.AccountTeacherId).TenNguoiDung;
                result.Add(tam);
            }
            return result;
        }

        public bool CreateFavouritesubject(int ida, int idsubject)
        {
            return studentSubjectRepositories.CreateFavouritesubject(ida, idsubject);
        }
    }
}
