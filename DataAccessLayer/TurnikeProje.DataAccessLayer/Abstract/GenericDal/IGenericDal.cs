using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Abstract.GenericDal
{
    public interface IGenericDal<T> where T : class
    {
       void Insert(T entity);
       void Delete(T entity);
       void Update(T entity);
       T GetById(int id);
       List<T> GetListAll();
       List<T> GetListAll(Expression<Func<T, bool>> filter);

    }
}
