using LMS.DTO.Request.TopicSubject;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface ITopicSubjectService
    {
        List<TopicSubject> getALL();
        List<GetAllTopicSubject> GetAllTopicSubject(int id);
    }
    public class TopicSubjectService : ITopicSubjectService
    {
        private readonly ITopicSubjectRepositories topicSubjectService;
        public TopicSubjectService(ITopicSubjectRepositories topicSubjectService)
        {
            this.topicSubjectService = topicSubjectService;
        }
    
        public List<TopicSubject> getALL()
        {
            throw new NotImplementedException();
        }

        public List<GetAllTopicSubject> GetAllTopicSubject(int id)
        {
            var a = topicSubjectService.GetAllTopicSubject(id);
            List<GetAllTopicSubject> result = new();

            foreach (var item in a)
            {
                GetAllTopicSubject tam = new();
                tam.NameTopicSubject = item.NameTopicSubject;
                result.Add(tam);
            }

            return result;
        }
    }
}
