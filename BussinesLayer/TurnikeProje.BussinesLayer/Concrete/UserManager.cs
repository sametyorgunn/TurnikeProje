using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.BussinesLayer.Abstract;
using TurnikeProje.DataAccessLayer.Abstract;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.BussinesLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(User entity)
        {
            _userDal.Delete(entity);    
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> TGetListAll()
        {
            return _userDal.GetListAll();
        }

        public List<User> TGetListAll(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetListAll(filter);
        }

        public void TInsert(User entity)
        {
            _userDal.Insert(entity);
        }

        public void TUpdate(User entity)
        {
           _userDal.Update(entity);
        }
    }
}
