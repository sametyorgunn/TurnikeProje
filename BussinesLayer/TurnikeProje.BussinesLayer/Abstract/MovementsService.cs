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
    public interface MovementsService:IGenericService<Movement>
    {
        List<Movement> TGetUserMovementsTime(int userId);
        void TCreateMovements(CreateMovementsDto dto);
        void TCreateExitTime(int id);

    }
}
