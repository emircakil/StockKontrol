using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stokDeneme
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly string _connectionString;

        public MusteriRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ekle(Musteri musteri)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Musteriler (Id,Ad, Soyad, Numara) VALUES (@Id,@Ad, @Soyad, @Numara)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", musteri.Id);
                    command.Parameters.AddWithValue("@Ad", musteri.Ad);
                    command.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                    command.Parameters.AddWithValue("@Numara", musteri.Numara);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Guncelle(Musteri musteri)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, Numara = @Numara WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", musteri.Id);
                    command.Parameters.AddWithValue("@Ad", musteri.Ad);
                    command.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                    command.Parameters.AddWithValue("@Numara", musteri.Numara);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Sil(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Musteriler WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Musteri> GetirTumMusteriler()
        {
            List<Musteri> musteriler = new List<Musteri>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Ad, Soyad, Numara FROM Musteriler";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Musteri musteri = new Musteri
                            {
                                Id = (int)reader["Id"],
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                Numara = (int)reader["Numara"],
                              
                            };
                            musteriler.Add(musteri);
                        }
                    }
                }
            }

            return musteriler;
        }
    }
}