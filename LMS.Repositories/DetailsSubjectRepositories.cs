using LMS.Context;
using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public interface IDetailsSubjectRepositories
    {
        bool create(DetailsSubject DetailsSubject);
        bool update(DetailsSubject DetailsSubject);
        bool GetAll(DetailsSubject DetailsSubject);

    }
    public class DetailsSubjectRepositories : IDetailsSubjectRepositories
    {
        private readonly AppDbContext context;
        public DetailsSubjectRepositories(AppDbContext context)
        {
            this.context = context;
        }
        public bool create(DetailsSubject DetailsSubject)
        {
            throw new NotImplementedException();
        }

        public bool GetAll(DetailsSubject DetailsSubject)
        {
            throw new NotImplementedException();
        }

        public bool update(DetailsSubject DetailsSubject)
        {
            throw new NotImplementedException();
        }
    }
}
