using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GEN_Planlama
{
    public partial class Frm_AdminEnvanter : Form
    {
        public Frm_AdminEnvanter()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        bool durum = false;

        void EtütSayısı()
        {
            OleDbCommand komut = new OleDbCommand("Select COUNT(*) From [Envanter Listesi$] where Durum = 'A'", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblEtütSayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        void Listele()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Envanter Listesi$] where Durum = 'A'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Listele2()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Envanter Listesi$] where Durum = 'P'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Listele3()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Envanter Listesi$] where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' and OPKODU LIKE '%" + txtOpAd.Text + "%'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Frm_Envanter_Load(object sender, EventArgs e)
        {
            try
            {
                Listele();
                EtütSayısı();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frm_KullaniciGiris _KullaniciGiris = new Frm_KullaniciGiris();
            this.Hide();
            _KullaniciGiris.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (durum == false)
                {
                    Listele2();
                    durum = true;
                }
                else if (durum == true)
                {
                    Listele();
                    durum = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("Update [Envanter Listesi$] set Durum = @p1 where ID = @p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", ctxtDurum.Text);
                komut.Parameters.AddWithValue("@p2", txtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                Temizle();
                EtütSayısı();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        void Temizle()
        {
            txtID.Text = "";
            ctxtDurum.SelectedItem = null;
            txtGmAd.Text = "";
            txtOpAd.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                ctxtDurum.SelectedItem = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                Listele3();
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnSorumlu_Click(object sender, EventArgs e)
        {
            Frm_AdminSorumlu _AdminSorumlu = new Frm_AdminSorumlu();
            _AdminSorumlu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_AdminKullaniciEkle _AdminKullaniciEkle = new Frm_AdminKullaniciEkle();
            _AdminKullaniciEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_AdminPersonelEkle _AdminPersonelEkle = new Frm_AdminPersonelEkle();
            _AdminPersonelEkle.Show();
        }
    }
}
