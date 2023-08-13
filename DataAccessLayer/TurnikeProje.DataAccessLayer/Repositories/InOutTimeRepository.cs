using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.DataAccessLayer.Abstract;
using TurnikeProje.DataAccessLayer.Contexts;
using TurnikeProje.DataAccessLayer.Repositories.GenericRepositorie;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Repositories
{
    public class InOutTimeRepository : EfGenericRepository<InOutTime>, IInOutTimeDal
    {
        public List<InOutTime> GetUserInOutTime(int userId)
        {
            using(var c = new AppDbContext())
            {
                var giriscikis = c.InOutTimes.Where(x => x.KullaniciId == userId).ToList();
                return giriscikis;
            }
        }
    }
}
