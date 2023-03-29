using LMS.Context;
using LMS.DTO.Request.TopicSubject;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface ITopicSubjectRepositories
    {
        public List<TopicSubject> GetAllTopicSubject(int id);
        bool create(TopicSubject TopicSubject);
        bool update(TopicSubject TopicSubject);
        bool GetAll(TopicSubject TopicSubject);

    }
    public class TopicSubjectRepositories : ITopicSubjectRepositories
    {
        private readonly AppDbContext context;
        public TopicSubjectRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool create(TopicSubject TopicSubject)
        {
            throw new NotImplementedException();
        }

        public bool GetAll(TopicSubject TopicSubject)
        {
            throw new NotImplementedException();
        }

        public List<TopicSubject> GetAllTopicSubject(int id)
        {
            var a = context.TopicSubject.Where(a => a.SubjectId == id).ToList();

            if (a == null) return null;
            return a;
        }

        public bool update(TopicSubject TopicSubject)
        {
            throw new NotImplementedException();
        }
    }
}
