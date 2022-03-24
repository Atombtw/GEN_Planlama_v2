using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_AdminPersonelEkle : Form
    {
        public Frm_AdminPersonelEkle()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();

        void Sayı()
        {
            OleDbCommand komut = new OleDbCommand("Select COUNT(*) From [Personel Listesi$]", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblSayı.Text = dr[0].ToString();
                int sayi1 = Convert.ToInt32(lblSayı.Text);
                txtID.Text = Convert.ToString(sayi1 + 1);
            }
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            txtID.Text = "";
            txtKullanıcıAd.Text = "";
            ctxtDurum.Text = "";
        }

        void Listele()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Personel Listesi$]", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void Frm_AdminPersonelEkle_Load(object sender, EventArgs e)
        {
            Sayı();
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtKullanıcıAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                ctxtDurum.SelectedItem = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
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
                OleDbCommand komut = new OleDbCommand("insert into [Personel Listesi$] (ID, PERSONEL_ADI, DURUM) values (@p1, @p2, @p3)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtID.Text);
                komut.Parameters.AddWithValue("@p2", txtKullanıcıAd.Text);
                komut.Parameters.AddWithValue("@p3", ctxtDurum.Text);
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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("Update [Personel Listesi$] set PERSONEL_ADI = @p1, DURUM = @p2 where ID = @p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanıcıAd.Text);
                komut.Parameters.AddWithValue("@p2", ctxtDurum.Text);
                komut.Parameters.AddWithValue("@p3", txtID.Text);
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
            Frm_AdminEnvanter _AdminEnvanter = new Frm_AdminEnvanter();
            this.Hide();
            _AdminEnvanter.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
    }
}
