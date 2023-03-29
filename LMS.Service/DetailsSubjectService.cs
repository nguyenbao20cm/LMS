using LMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface IDetailsSubjectService
    {
        List<DetailsSubject> GetALL();
    }
    public class DetailsSubjectService : IDetailsSubjectService
    {
        public List<DetailsSubject> GetALL()
        {
            throw new NotImplementedException();
        }
    }
}
