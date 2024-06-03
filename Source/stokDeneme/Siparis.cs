using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{
    public class Siparis
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public DateTime Tarih { get; set; }
        public int ToplamFiyat { get; set; }
    }
    
}
