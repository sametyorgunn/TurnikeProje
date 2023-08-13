using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.BussinesLayer.Abstract.GenericService;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.BussinesLayer.Abstract
{
    public interface IInOutTimeService:IGenericService<InOutTime>
    {
        List<InOutTime> GetUserInOutTime(int userId);

    }
}
