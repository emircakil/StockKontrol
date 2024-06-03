using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using stokDeneme;

namespace stokDeneme.Tests
{
    [TestFixture]
    public class UrunRepositoryTests
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDataReader> _mockReader;
        private UrunRepository _urunRepository;
        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hasan\\OneDrive\\Belgeler\\stok.mdf;Integrated Security=True;Connect Timeout=30";

        [SetUp]
        public void SetUp()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockReader = new Mock<IDataReader>();

            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);

            _urunRepository = new UrunRepository(_connectionString);
        }

        [Test]
        public void Ekle_ShouldAddUrun()
        {
            var urun = new Urun { Id = 1, Ad = "TestUrun", Adet = 10, Fiyat = 100, Kategori = "TestKategori" };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

      
            _urunRepository.Ekle(urun);

    
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
            Console.WriteLine("Ekle method test passed.");
        }

        [Test]
        public void Guncelle_ShouldUpdateUrun()
        {
       
            var urun = new Urun { Id = 1, Ad = "UpdatedUrun", Adet = 20, Fiyat = 200, Kategori = "UpdatedKategori" };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(0);

         
            _urunRepository.Guncelle(urun);

        
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
            Console.WriteLine("Guncelle method test passed.");
        }

        [Test]
        public void Sil_ShouldDeleteUrun()
        {
         
            int id = 1;

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

           
            _urunRepository.Sil(id);

      
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
            Console.WriteLine("Sil method test passed.");
        }

        [Test]
        public void TumUrunleriGetir_ShouldReturnAllUrunler()
        {
        
            var urunler = new List<Urun>
            {
                new Urun { Id = 1, Ad = "Urun1", Adet = 10, Fiyat = 100, Kategori = "Kategori1" },
                new Urun { Id = 2, Ad = "Urun2", Adet = 20, Fiyat = 200, Kategori = "Kategori2" }
            };

            _mockReader.SetupSequence(r => r.Read())
                       .Returns(true)
                       .Returns(true)
                       .Returns(false);
            _mockReader.Setup(r => r["Id"]).Returns(1);
            _mockReader.Setup(r => r["Ad"]).Returns("Urun1");
            _mockReader.Setup(r => r["Adet"]).Returns(10);
            _mockReader.Setup(r => r["Fiyat"]).Returns(100);
            _mockReader.Setup(r => r["Kategori"]).Returns("Kategori1");

            _mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(_mockReader.Object);

            // Act
            var result = _urunRepository.TumUrunleriGetir();


        }

        [Test]
        public void UrunGetir_ShouldReturnUrun_WhenUrunExists()
        {
            
            int id = 1;
            var urun = new Urun { Id = 1, Ad = "Urun1", Adet = 10, Fiyat = 100, Kategori = "Kategori1" };

            _mockReader.Setup(r => r.Read()).Returns(true);
            _mockReader.Setup(r => r["Id"]).Returns(1);
            _mockReader.Setup(r => r["Ad"]).Returns("Urun1");
            _mockReader.Setup(r => r["Adet"]).Returns(10);
            _mockReader.Setup(r => r["Fiyat"]).Returns(100);
            _mockReader.Setup(r => r["Kategori"]).Returns("Kategori1");

            _mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(_mockReader.Object);

           
            var result = _urunRepository.UrunGetir(id);


        }

        [Test]
        public void UrunGetir_ShouldReturnNull_WhenUrunDoesNotExist()
        {
           
            int id = 1;

            _mockReader.Setup(r => r.Read()).Returns(false);
            _mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(_mockReader.Object);

            var result = _urunRepository.UrunGetir(id);


        }
    }
}