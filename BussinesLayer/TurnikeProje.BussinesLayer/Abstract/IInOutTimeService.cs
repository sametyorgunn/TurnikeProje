using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.BussinesLayer.Abstract.GenericService;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.BussinesLayer.Abstract
{
    public interface IInOutTimeService:IGenericService<InOutTime>
    {
        List<InOutTime> TGetUserInOutTime(int userId);
        void TCreateMovements(CreateMovementsDto dto);
        void TAddExitTime(int id);

    }
}
