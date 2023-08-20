﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.DataAccessLayer.Abstract.GenericDal;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Abstract
{
    public interface MovementsDal:IGenericDal<Movement>
    {
        List<Movement> GetUserMovementsTime(int userId);
        void CreateMovements(CreateMovementsDto dto);
        void CreateExitTime(int id);
        GetUserOneDayMovementsDto TGetUserOneDayMovements(int userId);



    }
}
