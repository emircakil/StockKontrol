using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace stokDeneme
{
    public partial class Form1 : Form
    {
        private readonly IUrunRepository _urunRepository;
        private readonly IMusteriRepository _musteriRepository;
        private readonly ISiparisRepository _siparisRepository;
        private Timer updateTimer;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hasan\\OneDrive\\Belgeler\\stok.mdf;Integrated Security=True;Connect Timeout=30";
            _urunRepository = new UrunRepository(connectionString);
            _musteriRepository = new MusteriRepository(connectionString);
            _siparisRepository = new SiparisRepository(connectionString);

            updateTimer = new Timer();
            updateTimer.Interval = 60000; // 1 dakika (60 saniye * 1000 milisaniye)
            updateTimer.Tick += timer1_Tick;

            MusterileriGoster();
        }

        private void MusterileriGoster()
        {
            List<Musteri> musteriler = _musteriRepository.GetirTumMusteriler();
            dataGridView3.Rows.Clear();

            foreach (Musteri musteri in musteriler)
            {
                dataGridView3.Rows.Add(musteri.Id, musteri.Ad, musteri.Soyad, musteri.Numara);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
      string.IsNullOrWhiteSpace(txtAd.Text) ||
      string.IsNullOrWhiteSpace(txtAdet.Text) ||
      string.IsNullOrWhiteSpace(txtKategori.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            Urun urun = null; 

            try
            {
                urun = new Urun
                {
                    Id = int.Parse(txtId.Text),
                    Ad = txtAd.Text,
                    Adet = int.Parse(txtAdet.Text),
                    Fiyat = int.Parse(txtFiyat.Text), 
                    Kategori = txtKategori.Text
                };

                // Boş değer kontrolü
                if (string.IsNullOrWhiteSpace(urun.Ad) || string.IsNullOrWhiteSpace(urun.Kategori))
                {
                    throw new Exception("Ad ve Kategori alanları boş bırakılamaz!");
                }

                // Adet ve fiyat negatif değer kontrolü
                if (urun.Adet <= 0 || urun.Fiyat <= 0)
                {
                    throw new Exception("Adet ve Fiyat alanları 0'dan büyük olmalıdır!");
                }

                _urunRepository.Ekle(urun);
                MessageBox.Show("Ürün başarıyla Eklendi");
                YenileDataGridView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Adet ve Fiyat alanlarına sayısal değer giriniz.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YenileDataGridView();
        }
        private void YenileDataGridView()
        {
            List<Urun> urunler = _urunRepository.TumUrunleriGetir();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            foreach (Urun urun in urunler)
            {
                dataGridView1.Rows.Add(urun.Id, urun.Ad, urun.Adet, urun.Fiyat, urun.Kategori);
                dataGridView2.Rows.Add(urun.Id, urun.Ad, urun.Adet, urun.Fiyat, urun.Kategori);
            }
            List<Siparis> siparisler = _siparisRepository.TumSiparisleriGetir();

            dataGridView4.Rows.Clear();
            foreach (Siparis siparis in siparisler)
            {

                Urun urun = _urunRepository.UrunGetir(siparis.UrunId);


                dataGridView4.Rows.Add(siparis.Id, siparis.MusteriId, urun.Ad, siparis.Adet, siparis.Tarih, siparis.ToplamFiyat);
            }
            List<Musteri> musteriler = _musteriRepository.GetirTumMusteriler();
            dataGridView3.Rows.Clear();
            foreach (Musteri musteri in musteriler)



                dataGridView3.Rows.Add(musteri.Id, musteri.Ad, musteri.Soyad, musteri.Numara);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtAra.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaMetni))
            {
                YenileDataGridView();
                return;
            }


            List<Urun> filtrelenmisUrunler = _urunRepository.TumUrunleriGetir()
                .Where(u => u.Ad.ToLower().Contains(aramaMetni) ||
                             u.Kategori.ToLower().Contains(aramaMetni))
                .ToList();

            dataGridView1.Rows.Clear();

            foreach (Urun urun in filtrelenmisUrunler)
            {
                dataGridView1.Rows.Add(urun.Id, urun.Ad, urun.Adet, urun.Fiyat, urun.Kategori);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            if (int.TryParse(txtId.Text, out int id))
            {
                DialogResult dialogResult = MessageBox.Show($"ID'si {id} olan ürünü silmek istediğinize emin misiniz?", "Ürün Silme Onayı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _urunRepository.Sil(id);
                    YenileDataGridView();
                    MessageBox.Show("Ürün başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün ID'si girin.");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtAra2.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaMetni))
            {
                YenileDataGridView();
                return;
            }


            List<Urun> filtrelenmisUrunler = _urunRepository.TumUrunleriGetir()
                .Where(u => u.Ad.ToLower().Contains(aramaMetni) ||
                             u.Kategori.ToLower().Contains(aramaMetni))
                .ToList();

            dataGridView2.Rows.Clear();

            foreach (Urun urun in filtrelenmisUrunler)
            {
                dataGridView2.Rows.Add(urun.Id, urun.Ad, urun.Adet, urun.Fiyat, urun.Kategori);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) ||
    string.IsNullOrWhiteSpace(textBox8.Text) ||
    string.IsNullOrWhiteSpace(textBox9.Text) ||
    string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }


            Musteri musteri = new Musteri
            {
                Id = int.Parse(textBox7.Text),
                Ad = textBox8.Text,
                Soyad = textBox9.Text,
                Numara = int.Parse(textBox10.Text)
            };

            _musteriRepository.Ekle(musteri);
            MessageBox.Show("Müşteri başarıyla eklendi.");
            MusterileriGoster();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
       string.IsNullOrWhiteSpace(txtAd.Text) ||
       string.IsNullOrWhiteSpace(txtAdet.Text) ||
       string.IsNullOrWhiteSpace(txtFiyat.Text) ||
       string.IsNullOrWhiteSpace(txtKategori.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            Urun urun = new Urun
            {
                Id = int.Parse(txtId.Text),
                Ad = txtAd.Text,
                Adet = int.Parse(txtAdet.Text),
                Fiyat = int.Parse(txtFiyat.Text),
                Kategori = txtKategori.Text
            };

            _urunRepository.Guncelle(urun);
            MessageBox.Show("Ürün başarıyla güncellendi");
            YenileDataGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox18.Text) ||
      string.IsNullOrWhiteSpace(textBox12.Text) ||
      string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            try
            {
                int musteriId = int.Parse(textBox18.Text);
                int urunId = int.Parse(textBox12.Text);
                int adet = int.Parse(textBox11.Text);
                DateTime tarih = dateTimePicker1.Value;
              

              
                Urun secilenUrun = _urunRepository.TumUrunleriGetir().Find(u => u.Id == urunId);

                if (secilenUrun != null && secilenUrun.Adet >= adet && adet > 0)
                {
                    int toplamFiyat = secilenUrun.Fiyat * adet;

                    Siparis siparis = new Siparis
                    {
                        MusteriId = musteriId,
                        UrunId = urunId,
                        Adet = adet,
                        Tarih = tarih,
                        ToplamFiyat = toplamFiyat
                    };

                    _siparisRepository.Ekle(siparis);
                    MessageBox.Show($"Sipariş başarıyla oluşturuldu. Toplam Fiyat: {toplamFiyat:C}");
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanlara geçerli değerler girin.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            catch (FormatException)
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli değerler girin.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            YenileDataGridView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;

            }
            if (int.TryParse(textBox1.Text, out int id))
            {
                DialogResult dialogResult = MessageBox.Show($"ID'si {id} olan ürünü silmek istediğinize emin misiniz?", "Ürün Silme Onayı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _siparisRepository.Sil(id);
                    YenileDataGridView();
                    MessageBox.Show("Ürün başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün ID'si girin.");
            }

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = textBox16.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaMetni))
            {
                YenileDataGridView();
                return;
            }


            List<Musteri> filtrelenmisMusteri = _musteriRepository.GetirTumMusteriler()
                .Where(u => u.Ad.ToLower().Contains(aramaMetni) ||
                             u.Soyad.ToLower().Contains(aramaMetni))
                .ToList();

            dataGridView3.Rows.Clear();

            foreach (Musteri musteri in filtrelenmisMusteri)
            {
                dataGridView3.Rows.Add(musteri.Id, musteri.Ad, musteri.Soyad, musteri.Numara);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) ||
      string.IsNullOrWhiteSpace(textBox8.Text) ||
      string.IsNullOrWhiteSpace(textBox9.Text) ||
      string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            Musteri musteri = new Musteri
            {
                Id = int.Parse(textBox7.Text),
                Ad = textBox8.Text,
                Soyad = textBox9.Text,
                Numara = int.Parse(textBox10.Text),

            };

            _musteriRepository.Guncelle(musteri);
            MessageBox.Show("Müşteri başarıyla güncellendi");
            YenileDataGridView();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string metin = textBox2.Text;
            List<Urun> urunler = _urunRepository.TumUrunleriGetir();
            List<Urun> eslesenUrunler = new List<Urun>();

            foreach (Urun urun in urunler)
            {
                if (metin.IndexOf(urun.Ad, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    eslesenUrunler.Add(urun);
                }
            }

            if (eslesenUrunler.Count > 0)
            {
                Urun enAzAdetUrun = eslesenUrunler.OrderBy(u => u.Adet).First();
                listBox1.Items.Add($"{enAzAdetUrun.Ad} - Adet: {enAzAdetUrun.Adet}");
            }
            else
            {
                MessageBox.Show("Metinde eşleşen ürün bulunamadı.", "Ürün Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return; 
            }
            FetchAndDisplayStockData();
            updateTimer.Start();
        }
        private void FetchAndDisplayStockData()
        {
            string apiKey = "EXRL1Y7XNVE5DYCU"; 
            string symbol = textBox3.Text; 
            string function = "TIME_SERIES_INTRADAY";
            string interval = "1min";
            string apiUrl = $"https://www.alphavantage.co/query?function={function}&symbol={symbol}&interval={interval}&apikey={apiKey}";

            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var stockData = JObject.Parse(response.Content);
                var timeSeries = stockData["Time Series (1min)"];
                var latestData = timeSeries.First;

                listBox2.Items.Clear(); // ListBox'ı temizle
                listBox2.Items.Add($"Açılış: {latestData.First["1. open"]}");
                listBox2.Items.Add($"Yüksek: {latestData.First["2. high"]}");
                listBox2.Items.Add($"Düşük: {latestData.First["3. low"]}");
                listBox2.Items.Add($"Kapanış: {latestData.First["4. close"]}");
                listBox2.Items.Add($"Hacim: {latestData.First["5. volume"]}");
            }
            else
            {
                MessageBox.Show("Veri alınamadı. Lütfen API anahtarınızı ve sembolü kontrol edin.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            if (int.TryParse(textBox7.Text, out int id))
            {
                DialogResult dialogResult = MessageBox.Show($"ID'si {id} olan müşteriyi silmek istediğinize emin misiniz?", "Ürün Silme Onayı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _musteriRepository.Sil(id);
                    YenileDataGridView();
                    MessageBox.Show("Müşteri başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün ID'si girin.");
            }
        }
    }
}






