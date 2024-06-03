using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{

    public class UrunRepository : IUrunRepository
    {
        private readonly string _connectionString;

        public UrunRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ekle(Urun urun)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Urunler (Id,Ad, Adet, Fiyat, Kategori) VALUES (@Id,@Ad, @Adet, @Fiyat, @Kategori)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Id", urun.Id);
                    command.Parameters.AddWithValue("@Ad", urun.Ad);
                    command.Parameters.AddWithValue("@Adet", urun.Adet);
                    command.Parameters.AddWithValue("@Fiyat", urun.Fiyat);
                    command.Parameters.AddWithValue("@Kategori", urun.Kategori);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Guncelle(Urun urun)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Urunler SET Ad = @Ad, Adet = @Adet, Fiyat = @Fiyat, Kategori = @Kategori WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", urun.Id);
                    command.Parameters.AddWithValue("@Ad", urun.Ad);
                    command.Parameters.AddWithValue("@Adet", urun.Adet);
                    command.Parameters.AddWithValue("@Fiyat", urun.Fiyat);
                    command.Parameters.AddWithValue("@Kategori", urun.Kategori);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Sil(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Urunler WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Urun> TumUrunleriGetir()
        {
            List<Urun> urunler = new List<Urun>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Ad, Adet, Fiyat, Kategori FROM Urunler";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Urun urun = new Urun
                        {
                            Id = (int)reader["Id"],
                            Ad = reader["Ad"].ToString(),
                            Adet = (int)reader["Adet"],
                            Fiyat = (int)reader["Fiyat"],
                            Kategori = reader["Kategori"].ToString()
                        };

                        urunler.Add(urun);
                    }
                }
            }

            return urunler;
        }
        public Urun UrunGetir(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Urunler WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Urun
                            {
                                Id = (int)reader["Id"],
                                Ad = reader["Ad"].ToString(),
                                Adet = (int)reader["Adet"],
                                Fiyat = (int)reader["Fiyat"],
                                Kategori = reader["Kategori"].ToString()
                            };
                        }
                    }
                }
            }
            return null; 
        }
    }

}
