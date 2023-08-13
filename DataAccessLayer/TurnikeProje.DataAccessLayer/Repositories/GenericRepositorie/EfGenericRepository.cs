using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.DataAccessLayer.Abstract.GenericDal;
using TurnikeProje.DataAccessLayer.Contexts;

namespace TurnikeProje.DataAccessLayer.Repositories.GenericRepositorie
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using(var c = new AppDbContext())
            {
               c.Remove(entity);
               c.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var c = new AppDbContext())
            {
                return c.Set<T>().Find(id);
            }
        }

        public List<T> GetListAll()
        {
            using (var c = new AppDbContext())
            {
                return c.Set<T>().ToList();
            }
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new AppDbContext())
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T entity)
        {
            using (var c = new AppDbContext())
            {
                c.Add(entity);
                c.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var c = new AppDbContext())
            {
                c.Update(entity);
                c.SaveChanges();
            }
        }
    }
}
