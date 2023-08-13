using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnikeProje.EntityLayer.Entities
{
    public class InOutTime
    {
        public int Id { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
