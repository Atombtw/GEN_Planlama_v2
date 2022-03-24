using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GEN_Planlama
{
    public partial class Frm_AdminKullaniciEkle : Form
    {
        public Frm_AdminKullaniciEkle()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        Frm_AdminEnvanter _AdminEnvanter = new Frm_AdminEnvanter();

        void Sayı()
        {
            OleDbCommand komut = new OleDbCommand("Select COUNT(*) From [Kullanıcı Listesi$]", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblSayı.Text = dr[0].ToString();
                int sayi1 = Convert.ToInt32(lblSayı.Text);
                txtID.Text = Convert.ToString(sayi1 + 1);
            }
            bgl.baglanti().Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _AdminEnvanter.Show();
        }

        void Listele()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Kullanıcı Listesi$]", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void Frm_AdminKullaniciEkle_Load(object sender, EventArgs e)
        {
            Listele();
            Sayı();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtKullanıcıAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtKullanıcıSifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                ctxtAdmin.SelectedItem = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                ctxtDurum.SelectedItem = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("insert into [Kullanıcı Listesi$] (ID, KULLANICI_ADI, KULLANICI_SIFRESI, KULLANICI_ADMIN, DURUM) values (@p1, @p2, @p3, @p4, @p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtID.Text);
                komut.Parameters.AddWithValue("@p2", txtKullanıcıAd.Text);
                komut.Parameters.AddWithValue("@p3", txtKullanıcıSifre.Text);
                komut.Parameters.AddWithValue("@p4", ctxtAdmin.Text);
                komut.Parameters.AddWithValue("@p5", ctxtDurum.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Temizle();
                Listele();
                Sayı();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        void Temizle()
        {
            txtID.Text = "";
            txtKullanıcıAd.Text = "";
            txtKullanıcıSifre.Text = "";
            ctxtAdmin.Text = "";
            ctxtDurum.Text = "";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("Update [Kullanıcı Listesi$] set KULLANICI_ADI = @p1, KULLANICI_SIFRESI = @p2, KULLANICI_ADMIN = @p3, DURUM = @p4 where ID = @p5", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanıcıAd.Text);
                komut.Parameters.AddWithValue("@p2", txtKullanıcıSifre.Text);
                komut.Parameters.AddWithValue("@p3", ctxtAdmin.Text);
                komut.Parameters.AddWithValue("@p4", ctxtDurum.Text);
                komut.Parameters.AddWithValue("@p5", txtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
    }
}
