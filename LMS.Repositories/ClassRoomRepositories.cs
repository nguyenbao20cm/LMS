using LMS.Context;
using LMS.Model.Model;

namespace LMS.Repositories
{
    public interface IClassRoomRepositories
    {
        bool create(ClassRoom classRoom);
        bool update(ClassRoom classRoom);
        public List<ClassRoom> GetAll();
        public ClassRoom getbyId(int id);

    }
    public class ClassRoomRepositories : IClassRoomRepositories
    {
        private readonly AppDbContext context;
        public ClassRoomRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public ClassRoom getbyId(int id)
        {
            return context.ClassRoom.Where(a => a.ClassRoomId == id).FirstOrDefault();
        }
        public bool create(ClassRoom classRoom)
        {
            context.Add(classRoom);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public List<ClassRoom> GetAll()
        {
            return context.ClassRoom.ToList();
        }

        public bool update(ClassRoom classRoom)
        {
            context.ClassRoom.Update(classRoom);
            int result = context.SaveChanges();
            return result > 0 ? true : false;


        }
    }
}
