using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Detayli_Telefon_Rehberi
{
    public partial class Kisi_Ekle : Form
    {
        public Kisi_Ekle()
        {
            InitializeComponent();
        }
        SqlConnection Veritabani = new SqlConnection("Data Source=DESKTOP-0SS6619\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Telefon_Rehberi");
        private void Kisi_Ekle_Load(object sender, EventArgs e)
        {
            
            

        }
        void temizle()
        {
            textAd.Text = "";
            textcins.Text = "";
            textFace.Text = "";
            textInsta.Text = "";
            textKyt.Text = "";
            textTel.Text = "";
            textTel2.Text = "";
            textTelev.Text = "";
            textTwit.Text = "";
            textAd.Focus();
        }
        private void buttonlist_Click(object sender, EventArgs e)
        {
            this.rehber_TabloTableAdapter.Fill(this.dataSet1.Rehber_Tablo);
        }

        private void buttonkaydet_Click(object sender, EventArgs e)
        {
            Veritabani.Open();
            SqlCommand komut = new SqlCommand("insert into Rehber_Tablo (tel_isim,tel_no,tel_no2,tel_evno,tel_tarih,kisi_instagram,kisi_twitter,kisi_facebook,kisi_cinsiyet) values (@isim,@no,@no2,@evno,@tarih,@insta,@twit,@face,@cins)",Veritabani);
            komut.Parameters.AddWithValue("@isim", textAd.Text);
            komut.Parameters.AddWithValue("@no", textTel.Text);
            komut.Parameters.AddWithValue("@no2", textTel2.Text);
            komut.Parameters.AddWithValue("@evno", textTelev.Text);
            komut.Parameters.AddWithValue("@tarih", textKyt.Text);
            komut.Parameters.AddWithValue("@insta", textInsta.Text);
            komut.Parameters.AddWithValue("@twit", textTwit.Text);
            komut.Parameters.AddWithValue("@face", textFace.Text);
            komut.Parameters.AddWithValue("@cins", textcins.Text);
            komut.ExecuteNonQuery();
            Veritabani.Close();
            MessageBox.Show("Kişi Eklendi");
            this.rehber_TabloTableAdapter.Fill(this.dataSet1.Rehber_Tablo);
        }

        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textAd.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textTel.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textTel2.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textTelev.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textInsta.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            textTwit.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            textFace.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            textKyt.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textcins.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            Veritabani.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Rehber_Tablo where tel_isim=@sil", Veritabani);
            komutsil.Parameters.AddWithValue("@sil", textAd.Text);
            komutsil.ExecuteNonQuery();
            Veritabani.Close();
            temizle();
            this.rehber_TabloTableAdapter.Fill(this.dataSet1.Rehber_Tablo);

        }

        private void buttontemiz_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void buttongunc_Click(object sender, EventArgs e)
        {
            Veritabani.Open();
            SqlCommand komutguncelle = new SqlCommand("update Rehber_Tablo set tel_isim=@isim,tel_no=@no,tel_no2=@no2,tel_evno=@evno,tel_tarih=@tarih,kisi_instagram=@insta,kisi_twitter=@twit,kisi_facebook=@face,kisi_cinsiyet=@cins Where tel_isim=@isim", Veritabani);
            komutguncelle.Parameters.AddWithValue("@isim", textAd.Text);
            komutguncelle.Parameters.AddWithValue("@no", textTel.Text);
            komutguncelle.Parameters.AddWithValue("@no2", textTel2.Text);
            komutguncelle.Parameters.AddWithValue("@evno", textTelev.Text);
            komutguncelle.Parameters.AddWithValue("@tarih", textKyt.Text);
            komutguncelle.Parameters.AddWithValue("@insta", textInsta.Text);
            komutguncelle.Parameters.AddWithValue("@twit", textTwit.Text);
            komutguncelle.Parameters.AddWithValue("@face", textFace.Text);
            komutguncelle.Parameters.AddWithValue("@cins", textcins.Text);
            komutguncelle.ExecuteNonQuery();
            Veritabani.Close();
            MessageBox.Show("Güncellendi");
            temizle();
            this.rehber_TabloTableAdapter.Fill(this.dataSet1.Rehber_Tablo);

        }
    }
}
