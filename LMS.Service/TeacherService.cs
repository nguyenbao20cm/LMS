using LMS.DTO.Request.ClassRoom;
using LMS.DTO.Request.DetailLesson;
using LMS.DTO.Request.Lesson;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.DTO.Request.TopicSubject;
using LMS.Model.Model;
using LMS.Repositories;
using Microsoft.AspNetCore.Http;
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
        bool UpdateDetailLesson(int id, string Name1, IFormFile DetailsLesson);
        List<GetDetailLesson> GetAllDetailLesson(int Idlesson);
        public bool CreateDetailLesson(int Idlesson, int IdAcc, string Name1, IFormFile DetailsLesson);
        GetLesson GetLesson(int id);
        List<GetAllClassRoom> GetAllClassRoom();
        bool CreateLesson(CreateLesson Lesson);
        bool UpdateLesson(int id,UpdateLesson Lesson);
        bool UpdateTopicSubject(int id, UpdateTopicSubject UpdateTopicSubject);
        public List<GetAllTopicSubject> GetAllTopicSubject(int id);
       public List<GetAllSubject> GetAllSubject();
        bool CreateTopicSubject(CreateTopicSubject TopicSubject);
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
        public List<GetAllSubject> GetAllSubject()
        {
            return teacherRepositories.GetAllSubject();
        }
        public List<GetAllTopicSubject> GetAllTopicSubject(int id)
        {
            return teacherRepositories.GetAllTopicSubject(id);
        }
        public GetLesson GetLesson(int id)
        {
            return teacherRepositories.GetLesson(id);
        }
        public bool UpdateTopicSubject(int id, UpdateTopicSubject UpdateTopicSubject)
        {
            TopicSubject topicSubject = new TopicSubject();

            topicSubject.TopicSubjectId = id;
            topicSubject.NameTopicSubject = UpdateTopicSubject.NameTopicSubject;
            return teacherRepositories.UpdateTopicSubject(topicSubject);
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

        public bool CreateTopicSubject(CreateTopicSubject TopicSubject)
        {
            TopicSubject result=new ();
            result.NameTopicSubject = TopicSubject.NameTopicSubject;
            result.SubjectId = TopicSubject.SubjectId;
            return teacherRepositories.CreateTopicSubject(result);
        }

        public bool CreateLesson(CreateLesson Lesson)
        {
            return teacherRepositories.CreateLesson(Lesson);
        }
        public List<GetAllClassRoom> GetAllClassRoom()
        {
            return teacherRepositories.GetAllClassRoom();
        }
        public bool UpdateLesson(int id,UpdateLesson Lesson)
        {
           
            return teacherRepositories.UpdateLesson(id,Lesson);
        }
        public bool CreateDetailLesson(int Idlesson, int IdAcc, string Name1, IFormFile DetailsLesson)
        {
            return teacherRepositories.CreateDetailLesson(Idlesson, IdAcc, Name1, DetailsLesson);
        }

        public bool UpdateDetailLesson(int id, string Name1, IFormFile DetailsLesson)
        {
            return teacherRepositories.UpdateDetailLesson(id,Name1,DetailsLesson);
        }

        public List<GetDetailLesson> GetAllDetailLesson(int Idlesson)
        {
           return teacherRepositories.GetAllDetailLesson(Idlesson);  
        }
    }
}

