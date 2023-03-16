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
        bool CheckIdSubject(int id);
        bool CreateInformationDetailSubject(AddDetailsSubject DetailsSubject);
        bool UpdateInformationDetailSubject(int id,UpdateDetailSubject DetailsSubject);
        bool DeleteInformationDetailSubject(int id);
        List<DetailsSubject> detailsSubjects(int id);
        bool UpdateDetailTeacherSubject(int id, UpdateSubject detailsSubject);
        DetailsSubjectRequest GetDetailsSubject(int IdSubject);
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
        public bool CheckIdSubject(int id)
        {
            return teacherRepositories.CheckIdSubject(id);
        }
        public bool CheckID(int id)
        {
            return teacherRepositories.CheckID(id);
        }
        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject)
        {
            return teacherRepositories.FindTeacherSubject(IdAcc, IdTeacherSubject);
        }
        public List<DetailsSubject> detailsSubjects(int id)
        {
            return teacherRepositories.DetailsSubject(id);
        }
        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject)
        {
            return teacherRepositories.FindTeacherSubject(IdAcc, NameTeacherSubject);
        }

        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            return teacherRepositories.GetAllTeachingSubject(id);
        }

        public DetailsSubjectRequest GetDetailsSubject(int IdSubject)
        {
           return teacherRepositories.GetDetailsSubject(IdSubject);
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
            if (teacherRepositories.GetById(id) == null)
            {

                return false;
            }
            else
            {
                Subject Tk = teacherRepositories.GetById(id);
                Tk.Name = detailsSubject.SubjectName;
                Tk.Document = detailsSubject.Document;
                Tk.Status = detailsSubject.Status;
                Tk.Describe = detailsSubject.Desc;

                return teacherRepositories.UpdateDetailTeacherSubject(Tk);
            }
           
        }
      public  bool CreateInformationDetailSubject(AddDetailsSubject DetailsSubject)
        {
            DetailsSubject result = new();
        
        result.SubjectId=DetailsSubject.SubjectId;  
            result.Title=DetailsSubject.Title;  
            result.Content=     DetailsSubject.Content;
            return teacherRepositories.CreateInformationDetailSubject(result);
        }

        public bool UpdateInformationDetailSubject(int id, UpdateDetailSubject DetailsSubject)
        {
            DetailsSubject result = new();

            result.DetailsSubjectId = id;
            result.Title = DetailsSubject.Title;
            result.Content = DetailsSubject.Content;
            return teacherRepositories.UpdateInformationDetailSubject(result);
        }

        public bool DeleteInformationDetailSubject(int id)
        {
            return teacherRepositories.DeleteInformationDetailSubject(id);
        }
    }
}
