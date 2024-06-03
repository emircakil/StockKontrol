using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{

    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
        public string Kategori { get; set; }
    }
 
}
