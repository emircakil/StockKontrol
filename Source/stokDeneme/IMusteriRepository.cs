using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{
    public interface IMusteriRepository
    {
        void Ekle(Musteri musteri);
        void Guncelle(Musteri musteri);
        void Sil(int id);
        List<Musteri> GetirTumMusteriler();  
    }
}
