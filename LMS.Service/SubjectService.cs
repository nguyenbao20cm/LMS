using LMS.DTO.Request.Subject;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMS.Service
{
    public interface ISubjectService
    {
        public List<GetSubject> GetAllSubject();
        public DetailsSubjectRequest GetDetailsSubject(int IdSubject);
        public bool create(CreateSubject Subject);
        public bool Approve(int id);


    }
    public class SubjectService:ISubjectService
    {
        private readonly ISubjectRepositories subjectRepositories;
        
        public SubjectService(ISubjectRepositories subjectRepositories)
        {
            this.subjectRepositories = subjectRepositories;
        }
        public bool Approve(int id)
        {
            var a = subjectRepositories.GetDetailsSubject(id);
            a.Status = "1";
            return subjectRepositories.Approve(a);
        }
        public List<GetSubject> GetAllSubject()
        {
            List<Subject> list =  subjectRepositories.GetAll();
            List<GetSubject> result= new();
            foreach (Subject subject in list)
            {
                GetSubject a = new();
                a.SubjectId = subject.SubjectId;
                a.Name = subject.Name;
                a.Describe = subject.Describe;
                a.Status = subject.Status;
                a.Document = subject.Document;
                
                result.Add(a);
            }
            return result;
        }
        public bool create(CreateSubject Subject)
        {
            Subject a = new();
            a.Name= Subject.Name;   
            a.Describe= Subject.Describe;
            a.Status= "2";
            a.Document= Subject.Document;
            return subjectRepositories.create(a);
        }
    

        public DetailsSubjectRequest GetDetailsSubject(int IdSubject)
        {
            var a = subjectRepositories.GetDetailsSubject(IdSubject);
            if (a == null)
            {
                return null;
            }
            DetailsSubjectRequest result = new();
            result.SubjectId = a.SubjectId;
            result.SubjectName = a.Name;
            result.Document = a.Document;
            result.Status = a.Status;
            result.Desc = a.Describe;
            return result;

        }
    }
}
