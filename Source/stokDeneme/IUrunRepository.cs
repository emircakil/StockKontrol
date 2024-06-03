using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{

    public interface IUrunRepository
    {
        void Ekle(Urun urun);
        void Guncelle(Urun urun);
        void Sil(int id);
        List<Urun>TumUrunleriGetir ();
        Urun UrunGetir(int id);

    }
  

}
