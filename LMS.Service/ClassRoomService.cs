using LMS.DTO.Request.ClassRoom;
using LMS.Model.Model;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public interface IClassRoomService
    {
        public bool Create(CreateClassRoomRequest createClassRoomRequest);
        public List<GetAllClassRoom> GetAllClassRoom();
        public bool Update(int id,CreateClassRoomRequest createClassRoomRequest);
    }
    public class ClassRoomService: IClassRoomService
    {
        private readonly ITaiKhoanRepository TaiKhoanRepository;
        private readonly IClassRoomRepositories IClassRoomRepositories;


        public ClassRoomService(IClassRoomRepositories IClassRoomRepositories,ITaiKhoanRepository TaiKhoanRepository)
        {
            this.TaiKhoanRepository = TaiKhoanRepository;
            this.IClassRoomRepositories = IClassRoomRepositories;
        }
        public bool Update(int id,CreateClassRoomRequest createClassRoomRequest)
        {
            var a = IClassRoomRepositories.getbyId(id);
            a.Name = createClassRoomRequest.Name;
            a.Describe = createClassRoomRequest.Describe;
            a.Quantity=createClassRoomRequest.Quantity;
            return IClassRoomRepositories.update(a);
        }
        public List<GetAllClassRoom> GetAllClassRoom()
        {
            var a = IClassRoomRepositories.GetAll();
            List<GetAllClassRoom> result = new();
            foreach (var item in a)
            {
                GetAllClassRoom tam = new();
                tam.ClassRoomId = item.ClassRoomId;
                tam.Name = item.Name;
                tam.Quantity = item.Quantity;
                tam.Describe = item.Describe;
                result.Add(tam);
            }
            return result;
        }
        public bool Create(CreateClassRoomRequest createClassRoomRequest)
        {
            ClassRoom result = new();
            if (createClassRoomRequest == null) return false;
            result.Name=createClassRoomRequest.Name;    
            result.Quantity=createClassRoomRequest.Quantity;
            result.Describe=createClassRoomRequest.Describe;
            return IClassRoomRepositories.create(result);
        }
    }
}
