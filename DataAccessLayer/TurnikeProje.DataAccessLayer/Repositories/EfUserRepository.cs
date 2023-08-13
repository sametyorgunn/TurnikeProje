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
    public class EfUserRepository : EfGenericRepository<User>, IUserDal
    {
        
    }
}
