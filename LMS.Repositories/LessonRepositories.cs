using LMS.Context;
using LMS.DTO.Request.Lesson;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface ILessonRepositories
    {
        bool create(Lesson Lesson);
        bool update(Lesson Lesson);
        bool GetAll(Lesson Lesson);
        public Lesson GetLesson(int id);


    }
    public class LessonRepositories : ILessonRepositories
    {
        private readonly AppDbContext context;
        public LessonRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool create(Lesson Lesson)
        {
            throw new NotImplementedException();
        }
        public Lesson GetLesson(int id)
        {
            var a = context.Lesson.Where(a => a.TopicSubjectId == id).FirstOrDefault();
            
            return a;
        }

        public bool GetAll(Lesson Lesson)
        {
            throw new NotImplementedException();
        }

        public bool update(Lesson Lesson)
        {
            throw new NotImplementedException();
        }
    }
}

