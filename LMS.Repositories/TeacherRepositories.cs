using LMS.Context;
using LMS.DTO.Request.Subject;
using LMS.DTO.Request.TeachingSubject;
using LMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public interface ITeacherRepositories
    {

        bool UpdateInformationDetailSubject(DetailsSubject DetailsSubject);
        bool DeleteInformationDetailSubject(int id);
        bool CheckIdSubject(int id);
        bool CreateInformationDetailSubject(DetailsSubject DetailsSubject);
        List<DetailsSubject> DetailsSubject(int id);
        Subject GetById(int id);
        bool UpdateDetailTeacherSubject(Subject detailsSubject);
        bool CheckID(int id);
        DetailsSubjectRequest GetDetailsSubject(int IdSubject);
        List<TeachingSubjectGetAll> GetAllTeachingSubject(int id);
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject);// Tim theo ma
        TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject);// Tim theo ten
        List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int id);// Tim theo ten
    }
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly AppDbContext context;

        public TeacherRepositories(AppDbContext context)
        {
            this.context = context;

        }
        public bool CheckIdSubject(int id)
        {
            var a = context.Subject.Where(x => x.SubjectId == id).FirstOrDefault();
            if (a != null)
                return true;
            else return false;
        }

        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, int IdTeacherSubject)
        {
            var a = context.TeachingSubject.
                    Include(c => c.ClassRoom)
                    .Include(c => c.Subject).
                    Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                    .Where(c => c.SubjectID == IdTeacherSubject).FirstOrDefault();
            if (a == null)
            {
                TeachingSubjectGetAll temp = null;
                return temp;
            }
            else
            {
                TeachingSubjectGetAll temp = new();
                temp.SubjectId = a.SubjectID;
                temp.SubjectName = a.Subject.Name;
                temp.Desc = a.Subject.Describe;
                temp.Status = a.Subject.Status;
                temp.Document = a.Subject.Document;
                return temp;
            }
        }

        public TeachingSubjectGetAll FindTeacherSubject(int IdAcc, string NameTeacherSubject)
        {

            var a = context.TeachingSubject.
                 Include(c => c.ClassRoom)
                 .Include(c => c.Subject).
                 Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                 .Where(c => c.Subject.Name.Contains(NameTeacherSubject)).FirstOrDefault();
            if (a == null)
            {
                TeachingSubjectGetAll temp = null;
                return temp;
            }
            else
            {
                TeachingSubjectGetAll temp = new();
                temp.SubjectId = a.SubjectID;
                temp.SubjectName = a.Subject.Name;
                temp.Desc = a.Subject.Describe;
                temp.Status = a.Subject.Status;
                temp.Document = a.Subject.Document;
                return temp;
            }


        }

        public List<TeachingSubjectGetAll> GetAllTeachingSubject(int id)
        {
            var a = context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).Where(c => c.AccountID == id).ToList();
            if (a != null)
            {
                List<TeachingSubjectGetAll> result = new();
                TeachingSubjectGetAll temp = new();
                foreach (var item in a)
                {
                    TeachingSubjectGetAll tam = new();
                    tam.SubjectId = item.SubjectID;
                    tam.SubjectName = item.Subject.Name;
                    tam.Desc = item.Subject.Describe;
                    tam.Status = item.Subject.Status;
                    tam.Document = item.Subject.Document;
                    result.Add(tam);
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public DetailsSubjectRequest GetDetailsSubject(int IdSubject)
        {
            var a = context.Subject.Where(x => x.SubjectId == IdSubject).FirstOrDefault();
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
        public bool CheckID(int id)
        {
            var check = context.TaiKhoan.Where(x => x.TaiKhoanId == id).FirstOrDefault();
            if (check == null) return false;
            else return true;
        }

        public List<TeachingSubjectGetAll> SortAllTeacherSubjectByName(int IdAcc)
        {
            var a = context.TeachingSubject.
                   Include(c => c.ClassRoom)
                   .Include(c => c.Subject).
                   Include(c => c.Account).Where(c => c.AccountID == IdAcc)
                   .OrderBy(c => c.Subject.Name)
                   .ToList();
            List<TeachingSubjectGetAll> result = new();
            TeachingSubjectGetAll temp = new();
            foreach (var item in a)
            {
                TeachingSubjectGetAll tam = new();
                tam.SubjectId = item.SubjectID;
                tam.SubjectName = item.Subject.Name;
                tam.Desc = item.Subject.Describe;
                tam.Status = item.Subject.Status;
                tam.Document = item.Subject.Document;
                result.Add(tam);
            }
            return result;
        }
        public Subject GetById(int id)
        {
            if (context.Subject.Where(x => x.SubjectId == id).FirstOrDefault() == null)
            {
                Subject temp = null;
                return temp;
            }
            else
            {
                return context.Subject.Where(x => x.SubjectId == id).FirstOrDefault();
            }
        }
        public bool UpdateDetailTeacherSubject(Subject detailsSubject)
        {
            context.Subject.Update(detailsSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }

        public List<DetailsSubject> DetailsSubject(int id)
        {
            var a = context.DetailsSubject.Where(a => a.SubjectId == id).ToList();
            if (a == null)
            {
                return null;
            }
            else
                return context.DetailsSubject.Where(a => a.SubjectId == id).ToList();
        }
        public bool CreateInformationDetailSubject(DetailsSubject DetailsSubject)
        {
            context.DetailsSubject.Add(DetailsSubject);
            var check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool UpdateInformationDetailSubject(DetailsSubject DetailsSubject)
        {
            context.DetailsSubject.Update(DetailsSubject);
            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool DeleteInformationDetailSubject(int id)
        {

            context.DetailsSubject.Remove(context.DetailsSubject.Where(i => i.DetailsSubjectId == id).FirstOrDefault());

            int check = context.SaveChanges();
            return check > 0 ? true : false;
        }


    }
}
