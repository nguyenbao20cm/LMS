using LMS.Context;
using LMS.DTO.Request.DetailLesson;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface IDetailsLessonRepositories
    {
        public List<DetailsLesson> GetAllDetailLesson(int Idlesson);
        bool create(DetailsLesson DetailsLesson);
        bool update(DetailsLesson DetailsLesson);
        bool GetAll(DetailsLesson DetailsLesson);

    }
    public class DetailsLessonRepositories : IDetailsLessonRepositories
    {
        private readonly AppDbContext context;
        public List<DetailsLesson> GetAllDetailLesson(int Idlesson)
        {
            var a = context.DetailsLesson.Where(a => a.LessonId == Idlesson).ToList();
            if (a == null) return null;
            return a;
        }
        public DetailsLessonRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool create(DetailsLesson DetailsLesson)
        {
            throw new NotImplementedException();
        }

        public bool GetAll(DetailsLesson DetailsLesson)
        {
            throw new NotImplementedException();
        }

        public bool update(DetailsLesson DetailsLesson)
        {
            throw new NotImplementedException();
        }
    }
}
