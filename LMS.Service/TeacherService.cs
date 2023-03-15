using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using LMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface ITeacherService
    {
        bool UpdateDetailTeacherSubject(int id, UpdateSubject detailsSubject);
        Task<ActionResult<DetailsSubject>> GetDetailsSubject(int id);
        bool CheckID(int id);
        List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int IdAcc);
        List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject);// Tim theo ma
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject);// Tim theo ten
    }
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepositories teacherRepositories;
        public TeacherService(ITeacherRepositories teacherRepositories)
        {
            this.teacherRepositories = teacherRepositories;
        }
        public bool CheckID(int id)
        {
            return teacherRepositories.CheckID(id);
        }
        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject)
        {
            return teacherRepositories.FindTeacherSubject(IdAcc, IdTeacherSubject);
        }

        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject)
        {
            return teacherRepositories.FindTeacherSubject(IdAcc, NameTeacherSubject);
        }

        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            return teacherRepositories.GetAllTeachingSubject(id);
        }

        public Task<ActionResult<DetailsSubject>> GetDetailsSubject(int id)
        {
           return teacherRepositories.GetDetailsSubject(id);
        }

        public List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int id)
        {
            return teacherRepositories.SortAllTeacherSubjectByName(id);
        }

        public bool UpdateDetailTeacherSubject(int id, UpdateSubject detailsSubject)
        {
            if (detailsSubject.SubjectName == null)
                return false;
            if (detailsSubject.Desc == null) return false;
            if (detailsSubject.Document == null)
                return false;
            Subject Tk = teacherRepositories.GetById(id);
            Tk.Name = detailsSubject.SubjectName;
            Tk.Document = detailsSubject.Document;
            Tk.Status = detailsSubject.Status;
            Tk.Describe = detailsSubject.Desc;

            return teacherRepositories.UpdateDetailTeacherSubject(Tk);
        }
    }
}
