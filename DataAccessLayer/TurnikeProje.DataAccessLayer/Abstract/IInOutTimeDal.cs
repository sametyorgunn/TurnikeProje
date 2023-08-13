using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.DataAccessLayer.Abstract.GenericDal;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Abstract
{
    public interface IInOutTimeDal:IGenericDal<InOutTime>
    {
        List<InOutTime> GetUserInOutTime(int userId);
    }
}
