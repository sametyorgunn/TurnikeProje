using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.EntityLayer.Dtos
{
    public class GetUserOneDayMovementsDto
    {
        public int MovementsId { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public TimeSpan? OutInDifference { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
