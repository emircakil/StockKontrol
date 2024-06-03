using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{
    public interface ISiparisRepository
    {
        void Ekle(Siparis siparis);
        void Sil(int id);
        List<Siparis> TumSiparisleriGetir();
    }
}
