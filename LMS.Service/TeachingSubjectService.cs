using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Migrations;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface ITeachingSubjectService
    {
        List<GetTeachingSB> getALL();
        public bool Create(CreateTeachingSubject create);
    }
    public class TeachingSubjectService : ITeachingSubjectService
    {
        private readonly ITeachingSubjectRepositories teachingSubjectRepositories;
        private readonly ITaiKhoanRepository taiKhoanRepository;
        public TeachingSubjectService(ITaiKhoanRepository taiKhoanRepository,ITeachingSubjectRepositories teachingSubjectRepositories)
        {
            this.teachingSubjectRepositories = teachingSubjectRepositories;
            this.taiKhoanRepository = taiKhoanRepository;
        
        }

        public bool Create(CreateTeachingSubject createTeachingSubject)
        {
            TeachingSubject result = new();
            result.AccountID = createTeachingSubject.AccountID;
            result.ClassRoomID=createTeachingSubject.ClassRoomID;
            result.SubjectID = createTeachingSubject.SubjectID;
            return teachingSubjectRepositories.Create(result);
        }
        public List<GetTeachingSB> getALL()
        {
            var a = teachingSubjectRepositories.GetAll();
            if (a != null)
            {
                List<GetTeachingSB> result = new();
                GetTeachingSB temp = new();
                foreach (var item in a)
                {
                    GetTeachingSB tam = new();
                    tam.SubjectId = item.SubjectID;
                    tam.SubjectName = item.Subject.Name;
                    tam.Desc = item.Subject.Describe;
                    tam.NameTeacher = taiKhoanRepository.GetById(item.AccountID).TenNguoiDung;
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
    }
}
