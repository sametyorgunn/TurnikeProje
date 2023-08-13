﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnikeProje.EntityLayer.Entities
{
    public class GirisCikisSaat
    {
        public int Id { get; set; }
        public DateTime GirisSaati { get; set; }
        public DateTime CikisSaati { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
