using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.BussinesLayer.Abstract;
using TurnikeProje.DataAccessLayer.Abstract;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.BussinesLayer.Concrete
{
    public class InOutTimeManager : IInOutTimeService
    {
        private readonly IInOutTimeDal _InOutdal;

        public InOutTimeManager(IInOutTimeDal ınOutdal)
        {
            _InOutdal = ınOutdal;
        }

        public List<InOutTime> TGetUserInOutTime(int userId)
        {
            return _InOutdal.GetUserInOutTime(userId);
        }

        public void TDelete(InOutTime entity)
        {
           _InOutdal.Delete(entity);
        }

        public InOutTime TGetById(int id)
        {
            return _InOutdal.GetById(id);
        }

        public List<InOutTime> TGetListAll()
        {
            return _InOutdal.GetListAll();
        }

        public List<InOutTime> TGetListAll(Expression<Func<InOutTime, bool>> filter)
        {
           return _InOutdal.GetListAll(filter);
        }

        public void TInsert(InOutTime entity)
        {
            _InOutdal.Insert(entity);
        }

        public void TUpdate(InOutTime entity)
        {
            _InOutdal.Update(entity);
        }

        public void TCreateMovements(CreateMovementsDto dto)
        {
            _InOutdal.CreateMovements(dto);
        }

        public void TAddExitTime(int id)
        {
            _InOutdal.TAddExitTime(id);
        }

      

    }
}
