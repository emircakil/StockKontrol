using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{
    public class SiparisRepository : ISiparisRepository
    {
        private readonly string _connectionString;

        public SiparisRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ekle(Siparis siparis)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertSiparisQuery = "INSERT INTO Siparisler (MusteriId, UrunId, Adet, Tarih,ToplamFiyat) VALUES (@MusteriId, @UrunId, @Adet, @Tarih,@ToplamFiyat)";
                    using (SqlCommand command = new SqlCommand(insertSiparisQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                        command.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                        command.Parameters.AddWithValue("@Adet", siparis.Adet);
                        command.Parameters.AddWithValue("@Tarih", siparis.Tarih);
                        command.Parameters.AddWithValue("@ToplamFiyat", siparis.ToplamFiyat);
                        command.ExecuteNonQuery();
                    }

                    string updateUrunQuery = "UPDATE Urunler SET Adet = Adet - @Adet WHERE Id = @UrunId";
                    using (SqlCommand command = new SqlCommand(updateUrunQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Adet", siparis.Adet);
                        command.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void Sil(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Siparisler WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Siparis> TumSiparisleriGetir()
        {
            List<Siparis> siparisler = new List<Siparis>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Siparisler";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Siparis siparis = new Siparis
                        {
                            Id = (int)reader["Id"],
                            MusteriId = (int)reader["MusteriId"],
                            UrunId = (int)reader["UrunId"],
                            Adet = (int)reader["Adet"],
                            Tarih = (DateTime)reader["Tarih"],
                            ToplamFiyat = (int)reader["ToplamFiyat"]
                        };
                        siparisler.Add(siparis);
                    }
                }
            }
            return siparisler;
        }
        
    }
}
