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
    public class MovementsManager : IMovementsService
    {
        private readonly IMovementsDal _movementsDal;

        public MovementsManager(IMovementsDal movementsDal)
        {
            _movementsDal = movementsDal;
        }

        public void TCreateExitTime(int id)
        {
            _movementsDal.CreateExitTime(id);
        }

        public void TCreateMovements(CreateMovementsDto dto)
        {
            _movementsDal.CreateMovements(dto);
        }

        public void TDelete(Movement entity)
        {
            _movementsDal.Delete(entity);
        }

        public Movement TGetById(int id)
        {
            return _movementsDal.GetById(id);
        }

        public List<Movement> TGetListAll()
        {
           return _movementsDal.GetListAll();
        }

        public List<Movement> TGetListAll(Expression<Func<Movement, bool>> filter)
        {
            return _movementsDal.GetListAll(filter);
        }

        public List<Movement> TGetUserMovementsFilter(int userId, DateTime EnterDate, DateTime ExitDate)
        {
            return _movementsDal.GetUserMovementsFilter(userId, EnterDate, ExitDate);
        }

        public List<Movement> TGetUserMovementsTime(int userId)
        {
          return _movementsDal.GetUserMovementsTime(userId);
        }

        public GetUserOneDayMovementsDto TGetUserOneDayMovements(int userId)
        {
           return _movementsDal.TGetUserOneDayMovements(userId);
        }

        public void TInsert(Movement entity)
        {
            _movementsDal.Insert(entity);
        }

        public void TUpdate(Movement entity)
        {
            _movementsDal.Update(entity);
        }
    }
}
