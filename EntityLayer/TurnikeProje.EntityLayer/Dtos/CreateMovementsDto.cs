using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnikeProje.EntityLayer.Dtos
{
    public class CreateMovementsDto
    {
        public DateTime? InTime { get; set; }
        //public DateTime? OutTime { get; set; }
        public int UserId { get; set; }

    }
}
