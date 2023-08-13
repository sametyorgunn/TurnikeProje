using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnikeProje.EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public List<InOutTime> girisCikis { get; set; }
    }
}
