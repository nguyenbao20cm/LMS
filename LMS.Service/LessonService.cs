using LMS.DTO.Request.Lesson;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface ILessonService
    {
        List<Lesson> GetALL();
        public GetLesson GetLesson(int id);
    }
    public class LessonService : ILessonService
    {
        private readonly ILessonRepositories lessonRepositories;
        public LessonService(ILessonRepositories lessonRepositories)
        {
            this.lessonRepositories=        lessonRepositories;
        }
        public List<Lesson> GetALL()
        {
            throw new NotImplementedException();
        }
        public GetLesson GetLesson(int id)
        {
           var a = lessonRepositories.GetLesson(id);
            if (a == null) return null;
            GetLesson result = new();
        result.Title = a.Title;
            result.Content = a.Content;
            result.Describe = a.Describe;
            result.ClassRoomId = a.ClassRoomId;
            result.TopicSubjectId = a.TopicSubjectId;
            return result;}
}
}
